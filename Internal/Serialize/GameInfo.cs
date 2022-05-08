using AGCGM.Behavior;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AGCGM.Internal.Serialize
{
    [Serializable]
    public class GameInfo
    {
        //Miembros estaticos publicos.
        public static string XMLFileName { get; } = Properties.Settings.Default.GameInfoFile;

        //Miembros privados.
        private string XMLFilePath;

        //Propiedades publicas.
        public List<GameInfoItem> Games { get; } = new List<GameInfoItem>();

        //Metodos estaticos.
        public static GameInfo Load(string path)
        {
            GameInfo info = null;

            try
            {
                using (XmlReader xml = XmlReader.Create((path = Path.Combine(path, XMLFileName))))
                    info = new XmlSerializer(typeof(GameInfo)).Deserialize(xml) as GameInfo;
            }
            catch
            {
                info = new GameInfo();
            }

            info.XMLFilePath = path;
            return info;
        }

        //Metodos de instancia.
        public void Save()
        {
            try
            {
                if (Games.Count == 0)
                {
                    if (File.Exists(XMLFilePath)) File.Delete(XMLFilePath);
                }
                else
                {
                    using (StreamWriter file = File.CreateText(XMLFilePath))
                        new XmlSerializer(typeof(GameInfo)).Serialize(file, this);
                }
            }
            catch (Exception ex) { ex.AddLog(Log.LogLevel.Error, XMLFilePath); }
        }

        //Buscar item.
        public GameInfoItem Find(string GameID)
        {
            IEnumerable<GameInfoItem> result = Games.Where((item) => item.GetCodeID() == GameID);
            return result.Count() > 0 ? result.First() : null;
        }
    }
}
