using AGCGM.Internal.IO.GC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Behavior
{
    public static class GameCover
    {
        public enum Type
        {
            Front,
            Disc,
            Full,
            Front3D
        }

        public static Type[] GetAllTypes()
        {
            /*return new Type[]{
                Type.Front,
                Type.Front3D,
                Type.Full,
                Type.Disc
            };*/

            return (Type[])Enum.GetValues(typeof(Type));
        }     

        public static string GetPath(Type type)
        {
            switch (type)
            {
                case Type.Front:
                    return Properties.Settings.Default.CacheCoverFront;
                case Type.Front3D:
                    return Properties.Settings.Default.CacheCoverFront3D;
                case Type.Disc:
                    return Properties.Settings.Default.CacheCoverDisk;
                case Type.Full:
                    return Properties.Settings.Default.CacheCoverFull;
                default:
                    return null;
            }
        }

        public static IEnumerable<string> GetAllPaths() => GetAllTypes().Select(type => GetPath(type));

        public static bool ExistAll(string gameCode) => 
            GetAllPaths().Where(path => !File.Exists(Path.Combine(path, $"{gameCode}.png"))).Count() == 0;

        public static bool Exist(Type type, string gameCode) => File.Exists(Path.Combine(GetPath(type), $"{gameCode}.png"));

        public static string GetUrl(string url, DiskGC.Language lang, string code) => url.Replace("%REGION%", GetRegion(lang)).Replace("%IDPNG%", $"{code}.png");

        public static string GetRegion(DiskGC.Language lang)
        {
            switch (lang)
            {
                case DiskGC.Language.Japones:
                    return "JA";
                case DiskGC.Language.Aleman:
                    return "DE";
                case DiskGC.Language.Frances:
                    return "FR";
                case DiskGC.Language.Español:
                    return "ES";
                case DiskGC.Language.Italiano:
                    return "IT";
                case DiskGC.Language.Holandes:
                    return "NL";
                case DiskGC.Language.Ingles:
                    return "EN";
                default:
                    return "US";
            }
        }
        /*
        public string[] GetUrls(Type type)
        {
            string url = $"https://art.gametdb.com/wii/{0}/";

            switch (type)
            {
                case Type.Front:

                    break;
                case Type.Disc:
                    break;
                case Type.Full:
                    break;
                case Type.Front3D:
                    break;
            }

            return ;
        }

    */
        //public static string[] GetUrls(string gameCode) => PriorityRegion.Select(lang => "{0}/{1}.png").ToArray();
    }
}
