using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Internal.Tools
{
    internal static class ResXManager
    {
        public static ImageList GetImageList(Type ResourceType, Size size, Func<string, bool> condition = null)
        {
            //Arreglando parametro.
            if (condition is null) condition = (_) => true;

            //Obteniendo stream del archivo de recursos incrustado.
            using (Stream stream = GetStream($"{ResourceType.FullName}.resources"))
            {
                using (ResourceReader reader = new ResourceReader(stream))
                {
                    //Generando image list.
                    ImageList List = new ImageList() { ImageSize = size };
                    reader.Cast<DictionaryEntry>().Where((entry) => condition(entry.Key.ToString())).AsParallel().ForAll(
                        (entry) => List.Images.Add(entry.Key.ToString(), entry.Value as Image
                    ));
                    return List;
                }
            }
        }

        private static Stream GetStream(string basename) => typeof(ResXManager).Assembly.GetManifestResourceStream(basename);
    }
}
