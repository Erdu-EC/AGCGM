using AGCGM.Behavior;
using AGCGM.Internal.IO;
using AGCGM.Internal.IO.GC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AGCGM.Internal.Configs
{
    [Serializable]
    public class Settings
    {
        //Miembros privados.
        private static readonly string ConfigDirectory = Properties.Settings.Default.ConfigDirectory;
        private static readonly string ConfigFile = Properties.Settings.Default.ConfigFile;

        //Metodos estaticos.
        private static string GetConfigPath() => Path.Combine(ConfigDirectory ?? "", ConfigFile ?? "");

        //Propiedades publicas de listas de configuraciones.
        public bool SubDirectories { get; set; } = true;
        public List<DriveData> Drives { get; set; } = new List<DriveData>();
        public List<DirectoryData> Directories { get; set; } = new List<DirectoryData>();

        public List<CoverData> Covers { get; set; } = new List<CoverData>();

        public List<CoverRegionData> CoverRegions { get; set; } = new List<CoverRegionData>();

        public Settings()
        {
            if (Covers.Count == 0)
            {
                Covers.AddRange(new CoverData[] {
                    new CoverData(GameCover.Type.Disc, true, new List<CoverSourceData>(){
                        new CoverSourceData("art.gametdb.com/wii/disc/%REGION%/%IDPNG%", true),
                        new CoverSourceData("art.gametdb.com/wii/disccustom/%REGION%/%IDPNG%", true)
                    }),
                    new CoverData(GameCover.Type.Front, true, new List<CoverSourceData>(){
                        new CoverSourceData("art.gametdb.com/wii/cover/%REGION%/%IDPNG%", true)
                    }),
                    new CoverData(GameCover.Type.Front3D, true, new List<CoverSourceData>(){
                        new CoverSourceData("art.gametdb.com/wii/cover3D/%REGION%/%IDPNG%", true)
                    }),
                    new CoverData(GameCover.Type.Full, true, new List<CoverSourceData>(){
                        new CoverSourceData("art.gametdb.com/wii/coverfullHQ/%REGION%/%IDPNG%", true),
                        new CoverSourceData("art.gametdb.com/wii/coverfull/%REGION%/%IDPNG%", true)
                    })
                });
            }

            if (CoverRegions.Count == 0)
            {
                CoverRegions.AddRange(new CoverRegionData[] {
                    new CoverRegionData(DiskGC.Language.Español, 1, true),
                    new CoverRegionData(DiskGC.Language.Ingles, 2, true),
                    new CoverRegionData(DiskGC.Language.Italiano, 3, true),
                    new CoverRegionData(DiskGC.Language.Holandes, 4, true),
                    new CoverRegionData(DiskGC.Language.Japones, 5, true),
                    new CoverRegionData(DiskGC.Language.Aleman, 6, true)
                });
            }
        }

        #region Metodos publicos. . .
        public DriveData GetDrive(string name, string label)
        {
            DriveData[] result = Drives.Where((drive) => drive.Name == name && drive.Label == label).AsParallel().ToArray();
            return result.Length > 0 ? result[0] : null;
        }

        public DriveData GetDrive(Drive data) => GetDrive(data.Name, data.Label);

        public DirectoryData GetDirectory(string path)
        {
            DirectoryData[] result = Directories.Where((entry) => entry.Path == path).AsParallel().ToArray(); ;
            return result.Length > 0 ? result[0] : null;
        }
        #endregion

        #region Guardar y cargar ajustes. . .
        public static Settings Load()
        {
            try
            {
                using (XmlReader xml = XmlReader.Create(GetConfigPath()))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    if (serializer.CanDeserialize(xml)) return (Settings)serializer.Deserialize(xml);
                }
            }
            catch (Exception) { }

            return new Settings();
        }

        public bool Save()
        {
            //try
            //{
            //Si directorio de configuracion no existe, crearlo.
            if (!Directory.Exists(ConfigDirectory)) System.IO.Directory.CreateDirectory(ConfigDirectory);

            //Guardando configuraciones.
            using (StreamWriter file = File.CreateText(GetConfigPath()))
                new XmlSerializer(typeof(Settings)).Serialize(file, this);

            return true;
            /*}
            catch
            {
                return false;
            }*/
        }
        #endregion
    }
}
