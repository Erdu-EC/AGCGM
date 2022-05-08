using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.IO.GC
{
    partial class DiskGC
    {
        /// <summary>
        /// Header: boot.bin (0 -> 1087) y bi2.bin (1088 -> 9279) = 9280 Bytes
        /// </summary>
        public class GCHeader
        {
            //Propiedades
            public char ConsoleCode { get; }
            public string GameCode { get; }
            public Country CountryCode { get; }
            public string MakerCode { get; }
            public int DiskID { get; }
            public string GameName { get; }
            public MagicsWord MagicWord { get; }
            public uint OffsetDOL { get; }
            public uint OffsetFST { get; }
            public int LengthFST { get; }
            public int MaxLengthFST { get; }

            //Propiedades independientes.
            public static int Length => 9280; //Bytes;

            //Miembros calculados.
            public string GetGameID() => $"{FullCode}-{DiskID}";

            public GCHeader(BinaryReader reader)
            {
                //Estableciendo posicion de la secuencia.
                reader.BaseStream.Position = 0;

                //Verificando tamaño de la cabecera.
                if (reader.BaseStream.Length < Length) throw new InvalidHeaderException("Imposible obtener el Header, el tamaño del Backup es muy pequeño.");

                //Extrayendo campos importantes de la cabecera del disco.
                //DiskHeader -> "boot.bin" (0 -> 1087‬)
                ConsoleCode = reader.ReadChar();                            //Offset = 0 : Size = 1
                GameCode = new string(reader.ReadChars(2));                 //Offset = 1 : Size = 2
                CountryCode = (Country)reader.ReadChar();                   //Offset = 3 : Size = 1
                MakerCode = new string(reader.ReadChars(2));                //Offset = 4 : Size = 2
                DiskID = reader.ReadChar();                                 //Offset = 6 : Size = 1
                reader.BaseStream.Position = 28;                            // . . .
                MagicWord = (MagicsWord) reader.ReadBytes(4).ToInt();        //Offset = 28 : Size = 4
                reader.BaseStream.Position = 32;                            // . . .
                GameName = new string(reader.ReadChars(992)).Trim('\0');    //Offset = 32 : Size = 992
                reader.BaseStream.Position = 1056;                          // . . .
                OffsetDOL = (uint)reader.ReadBytes(4).ToInt();              //Offset = 1056 : Size = 4
                OffsetFST = (uint)reader.ReadBytes(4).ToInt();              //Offset = 1060 : Size = 4
                LengthFST = reader.ReadBytes(4).ToInt();                    //Offset = 1064 : Size = 4
                MaxLengthFST = reader.ReadBytes(4).ToInt();                 //Offset = 1068 : Size = 4

                //Si no es un disco de GameCube.
                if (MagicWord != MagicsWord.GAMECUBE) throw new InvalidDiskException("El fichero especificado no corresponde a un Backup de juego GC.");
            }

            #region Here are: Console, Country, Maker, and Game Full Code...

            public string ConsoleName
            {
                get {
                    switch (ConsoleCode)
                    {
                        case 'G':
                        case 'D':
                            return "Gamecube";
                        default:
                            return "Desconocido";
                    }
                }
            }

            public string CountryName
            {
                get {
                    switch (CountryCode)
                    {
                        case Country.USA: return "NTSC-U";
                        case Country.EUROPE:
                        case Country.EUROPE_Z: return "PAL";
                        case Country.JAPAN: return "NTSC-J";
                        default: return "Desconocido";
                    }
                }
            }

            public string MakerName
            {
                get {
                    switch (MakerCode)
                    {
                        case "01": return "Nintendo";
                        case "08": return "Capcom";
                        case "41": return "Ubisoft";
                        case "4F": return "Eidos";
                        case "51": return "Acclaim";
                        case "52": return "Activision";
                        case "5D": return "Midway";
                        case "5G": return "Hudson";
                        case "64": return "Lucas Arts";
                        case "69": return "Electronic Arts";
                        case "6S": return "TDK Mediactive";
                        case "8P": return "Sega";
                        case "A4": return "Mirage Studios";
                        case "AF": return "Namco";
                        case "B2": return "Bandai";
                        case "DA": return "Tomy";
                        case "EM": return "Konami";
                        default: return "Desconocido";
                    }
                }
            }

            public string FullCode => ConsoleCode + GameCode + (char)CountryCode + MakerCode;

            #endregion

            public void Write(BinaryReader source, Stream destination, uint DOLOffset, uint FSTOffset)
            {
                //Estableciendo offset de ambas imagenes
                source.BaseStream.Position = destination.Position = 0;

                //Leyendo cabecera de la imagen original y escribiendola en la nueva imagen.
                destination.Write(source.ReadBytes(Length), 0, Length);

                //Modificando offsetDOL y offsetFST
                destination.Position = 1056;
                destination.Write(DOLOffset.ToBytes(4), 0, 4); //Offset = 1056 : Size = 4
                destination.Write(FSTOffset.ToBytes(4), 0, 4); //Offset = 1060 : Size = 4
            }
        }
    }
}
