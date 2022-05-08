using AGCGM.Internal.IO.GC.Files;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Behavior
{
    class Cache
    {
        private static readonly string BannerPath = Properties.Settings.Default.CacheBannerDir;
        private static readonly object CacheLock = new object();
        private static readonly object CoverLock = new object();

        public static Image GetBanner(string GameCode)
        {
            //Obteniendo nombre del archivo.
            string file = Path.Combine(BannerPath, $"{GameCode}.png");

            //Si banner existe, obtenerlo.
            Image image = File.Exists(file) ? Execute.Assign(() => Image.FromFile(file), false) : null;

            //Comprobar que sea del tamaño esperado.
            if (image != null && image.Size == BNR.Size)
                //Si es asi, devolverlo.
                return image;

            return null;
        }

        public static void SaveBanner(string GameCode, Image image)
        {
            //Obteniendo nombre del archivo.
            string path = Path.Combine(BannerPath, $"{GameCode}.png");

            //Si banner ya existe o imagen igual a null, salir.
            if (image is null || File.Exists(path)) return;

            lock (CacheLock)
            {
                //Si directorio temporal no existe, crearlo.
                if (!Directory.Exists(BannerPath)) Directory.CreateDirectory(BannerPath);

                //Creando banner.
                Execute.Run(() => image.Save(path, ImageFormat.Png));
            }
        }

        public static Image GetCover(string GameCode, GameCover.Type type)
        {
            //Obteniendo nombre del archivo.
            string file = Path.Combine(GameCover.GetPath(type), $"{GameCode}.png");

            //Si cover existe, obtenerlo.
            Image image = File.Exists(file) ? Execute.Assign(() => Image.FromFile(file), false) : null;

            //Devolverlo.
            return image;
        }

        public static void SaveCover(string GameCode, Image image, GameCover.Type type)
        {
            //Obteniendo path.
            string coverPath = GameCover.GetPath(type);

            //Obteniendo nombre del archivo.
            string path = Path.Combine(coverPath, $"{GameCode}.png");

            //Si cover ya existe o imagen igual a null, salir.
            if (image is null || File.Exists(path)) return;

            lock (CoverLock)
            {
                //Si directorio temporal no existe, crearlo.
                if (!Directory.Exists(coverPath)) Directory.CreateDirectory(coverPath);

                //Creando banner.
                Execute.Run(() => image.Save(path, ImageFormat.Png));
            }
        }

    }
}
