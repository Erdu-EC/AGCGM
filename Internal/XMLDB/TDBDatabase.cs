using AGCGM.Behavior;
using AGCGM.Lang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static AGCGM.Behavior.Log;
using IOPath = System.IO.Path;

namespace AGCGM.Internal.XMLDB
{
    internal partial class TDBDatabase
    {
        public string Path { get; }
        public long Version { get; private set; }
        public bool IsReady { get; }

        //Miembros privados.

        internal TDBDatabase(string path)
        {
            Path = IOPath.GetFullPath(path);
            IsReady = LoadDatabase(path, out long version);
            Version = version;
        }

        //Metodos privados.
        private static XmlReader CreateReader(string path)
        {
            //Creando y configurando lector.
            return XmlReader.Create(path, new XmlReaderSettings()
            {
                IgnoreWhitespace = true,
                IgnoreComments = true
            });
        }

        private static bool LoadDatabase(string path, out long version)
        {
            version = 0;

            //Abriendo archivo XML.
            try
            {
                using (XmlReader reader = CreateReader(path))
                {
                    reader.MoveToContent();

                    //Si no se ha alcanzado el final.
                    if (!reader.EOF)
                    {
                        //Obteniendo version de DB.
                        if (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == DB_NAME && reader.MoveToAttribute(DB_ATTR_VERSION))
                            {
                                version = reader.ReadContentAsLong();
                                AddLog(TDBStrings.DATABASE_DETECTED.FormatWith(version), LogLevel.Information, path);
                            }
                            else
                                AddLog(TDBStrings.DATABASE_UNKNOWN_DETECTED, LogLevel.Warning, path);

                            return true; //Habilitando BD.
                        }
                        else
                            AddLog(TDBStrings.DATABASE_NOT_ANALIZED, LogLevel.Error, path);
                    }
                    else
                        AddLog(TDBStrings.DATABASE_FILE_EMPTY, LogLevel.Error, path);
                }
            }
            catch (FileNotFoundException)
            {
                AddLog(TDBStrings.DATABASE_FILE_MISSING, LogLevel.Error, path);
            }
            catch (Exception ex)
            {
                ex.AddLog(LogLevel.Error, path);
            }

            return false;
        }

        private IEnumerable<XElement> GetXMLElements()
        {
            using (XmlReader reader = CreateReader(Path))
            {
                reader.MoveToContent();

                if (!reader.EOF && reader.Read())
                {
                    while (!reader.EOF)
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (XNode.ReadFrom(reader) is XElement el)
                                yield return el;
                        }
                        else
                            reader.Read();
                    }
                }
                else
                    AddLog(TDBStrings.DATABASE_FORMAT_UNKNOWN, LogLevel.Error, Path);
            }
        }

        public IEnumerable<TDBCompany> GetCompanies()
        {
            if (IsReady)
            {
                foreach (XElement node in GetXMLElements().Where((node) => node.Name == ITEM_COMPANY && node.HasAttributes))
                {
                    yield return new TDBCompany(
                        node.Attribute(ITEM_COMPANY_CODE)?.Value,
                        node.Attribute(ITEM_COMPANY_NAME)?.Value
                    );
                }
            }
        }

        public IEnumerable<TDBGame> GetGames()
        {
            if (!IsReady) yield break;

            foreach (XElement item in GetXMLElements().Where((item) => item.Name == ITEM_GAME && item.HasElements))
                yield return TDBGame.CreateFrom(item);
        }

        public TDBGame GetGameByCode(string code)
        {
            var result = GetXMLElements().Where((item) => item.Name == ITEM_GAME && item.HasElements && item.Element(TDBGame.F_ID).Value == code).AsParallel().SingleOrDefault();
            return TDBGame.CreateFrom(result);
        }
    }
}
