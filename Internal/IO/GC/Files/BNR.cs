using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using static AGCGM.Internal.IO.GC.DiskGC;

namespace AGCGM.Internal.IO.GC.Files
{
    public class BNR
    {
        //Miembros privados.
        private readonly bool isBNR1;

        //Propiedades.
        public Dictionary<Language, string> ShortName { get; }
        public Dictionary<Language, string> ShortDeveloper { get; }
        public Dictionary<Language, string> FullName { get; }
        public Dictionary<Language, string> FullDeveloper { get; }
        public Dictionary<Language, string> Description { get; }
        public Image Image { get; private set; }

        //Propiedades estaticas.
        public static Size Size { get; } = new Size(96, 32);

        public BNR(byte[] data, Country country, Image Banner = null)
        {
            //Determinando set de caracteres (CodePage=932, DisplayName="Japonés (Shift-JIS)", Name="shift_jis")
            Encoding encoding = country == Country.JAPAN ? Encoding.GetEncoding("shift_jis") : Encoding.UTF7;

            //Obteniendo reader y estableciendo set de caracteres.
            using (BinaryReader reader = new BinaryReader(new MemoryStream(data), encoding))
            {
                //Extrayendo campo
                isBNR1 = new string(reader.ReadChars(4)) == "BNR1";                                     //Offset = 0 : Size = 4
                reader.BaseStream.Position = 32;
                Image = Banner is null ? MakeBanner(reader.ReadBytes(6144), Size.Width, Size.Height) : Banner;    //Offset = 32 : Size = 6144

                //Inicializando propiedades
                ShortName = new Dictionary<Language, string>();
                ShortDeveloper = new Dictionary<Language, string>();
                FullName = new Dictionary<Language, string>();
                FullDeveloper = new Dictionary<Language, string>();
                Description = new Dictionary<Language, string>();

                //Estableciendo offset de inicio
                reader.BaseStream.Position = 6176;

                //Extrayendo campos en cada lenguaje
                for (int i = (country == Country.JAPAN) ? 0 : 1; i <= (isBNR1 ? 1 : 6) /*num_languages*/; i++)
                {
                    ShortName[(Language)i] = new string(reader.ReadChars(32)).Trim('\0');       //Offset = 6176 : Size = 32
                    ShortDeveloper[(Language)i] = new string(reader.ReadChars(32)).Trim('\0');  //Offset = 6208 : Size = 32
                    FullName[(Language)i] = new string(reader.ReadChars(64)).Trim('\0');        //Offset = 6240 : Size = 64
                    FullDeveloper[(Language)i] = new string(reader.ReadChars(64)).Trim('\0');   //Offset = 6304 : Size = 64
                    Description[(Language)i] = new string(reader.ReadChars(128)).Trim('\0');    //Offset = 6368 : Size = 128

                    if (isBNR1) break;
                }
            }
        }

        //Metodos publicos
        public string GetName(Language language)
        {
            string name = (isBNR1) ? FullName.First().Value : FullName[language];
            if (name is null || name == "") name = (isBNR1) ? ShortName.First().Value : ShortName[language];
            return name;
        }
        public string GetDeveloper(Language language)
        {
            string developer = (isBNR1) ? FullDeveloper.First().Value : FullDeveloper[language];
            if (developer is null || developer == "") developer = (isBNR1) ? ShortDeveloper.First().Value : ShortDeveloper[language];
            return developer;
        }

        //Metodos privados
        private Image MakeBanner(byte[] data, int width, int height)
        {
            //Generando lista de bytes
            List<byte> bin = data.ToList();

            //Inicializando arreglo de pixeles decodificados
            int pos = 0;
            int[] pixels = new int[width * height];

            //Decodificando pixeles RGB5A1 => RGB5A3
            for (int y = 0; y < height; y += 4)
            {
                for (int x = 0; x < width; x += 4)
                {
                    for (int y1 = 0; y1 < 4; y1++, pos += (4 * 2))
                    {
                        for (int x1 = 0; x1 < 4; x1++)
                        {
                            int pixel = bin.GetRange(pos + (x1 * 2), 2).ToArray().ToInt();
                            pixels[((y + y1) * width) + (x + x1)] = Decode5A3(pixel);
                        }
                    }
                }
            }

            //Creando imagen.
            Bitmap Image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Image.SetPixel(x, y, Color.FromArgb(pixels[y * width + x]));
            }

            //Devolviendola
            return Image;

            //return new Bitmap(width, height, 4 * width, PixelFormat.Format32bppArgb, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0)); //<- Problema con memoria protegida (T-T)
        }

        //Codigo extraido del emulador de software libre Dolphin. {::{
        private static int Convert5to8(int v)
        {
            return (((v << 3) | (v >> 2)) & 255);
        }

        private static int Convert3to8(int v)
        {
            return (((v << 5) | (v << 2) | (v >> 1)) & 255);
        }

        private static int Convert4to8(int v)
        {
            return (((v << 4) | v) & 255);
        }

        private static int Decode5A3(int val)
        {
            const uint bg_color = 0x00000000;

            int r, g, b, a;

            if ((val & 0x8000) > 0)
            {
                r = Convert5to8((val >> 10) & 0x1f);
                g = Convert5to8((val >> 5) & 0x1f);
                b = Convert5to8((val) & 0x1f);
                a = 0xFF;
            }
            else
            {
                a = Convert3to8((val >> 12) & 0x7);
                r = (int)(Convert4to8((val >> 8) & 0xf) * a + (bg_color & 0xFF) * (255 - a)) / 255;
                g = (int)(Convert4to8((val >> 4) & 0xf) * a + ((bg_color >> 8) & 0xFF) * (255 - a)) / 255;
                b = (int)(Convert4to8((val) & 0xf) * a + ((bg_color >> 16) & 0xFF) * (255 - a)) / 255;
                a = 0xFF;
            }
            return ((a << 24) | (r << 16) | (g << 8) | b);
        }
        //}::}
    }
}
