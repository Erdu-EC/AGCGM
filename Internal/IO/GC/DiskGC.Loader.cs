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
        public class GCLoader
        {
            //Propiedades
            public DateTime Date { get; }
            public uint EntryPoint { get; }
            public int LoaderSize { get; }
            public int TrailerSize { get; }
            public int Length => LoaderSize + TrailerSize + 28;

            //Miembros privados.
            private DiskGC Disc;

            public GCLoader(DiskGC disc, BinaryReader reader)
            {
                //Inicializando.
                Disc = disc;

                //Estableciendo offset de la secuencia.
                uint offset = (uint)GCHeader.Length;

                //Extrayendo campos importante de AppLoader.
                //AppLoader -> "appldr.bin" (9280 -> OffsetDOL)
                reader.BaseStream.Position = offset;                        // . . .
                Date = DateTime.Parse(new string(reader.ReadChars(10)));    //Offset: 0 : Size: 10
                reader.BaseStream.Position = offset + 16;                   // . . .
                EntryPoint = (uint)reader.ReadBytes(4).ToInt();             //Offset: 16 : Size: 4
                LoaderSize = reader.ReadBytes(4).ToInt();                   //Offset: 20 : Size: 4
                TrailerSize = reader.ReadBytes(4).ToInt();                  //Offset: 24 : Size: 4    
            }

            //Metodos publicos
            public void Write(BinaryReader source, Stream destination, GCHeader header, out uint DOLOffset, out FSFile DOLEntry, bool trim)
            {
                //Estableciendo posicion.
                //appldr.bin -> (9280 -> /*offsetDOL*/)
                source.BaseStream.Position = destination.Position = GCHeader.Length;

                //Leyendo cargador original y escribiendolo en la nueva imagen.
                destination.Write(source.ReadBytes(Length), 0, Length);

                //Aplicando PAD.
                if (trim) WritePad4(destination);

                //Verificando si el DOL existe en el sistema de fichero, y obteniendolo si es asi.
                FSFile sourceDOLFile = DOLEntry = Disc.GetDOLIfExistInFS();

                //Si no existe en el FS, escribirlo ahora.
                if (sourceDOLFile is null)
                {
                    //Determinando offset del DOL en la nueva imagen.
                    DOLOffset = (uint)destination.Position;

                    //Escribiendo DOL tal cual.
                    source.BaseStream.Position = header.OffsetDOL;
                    if (!trim) destination.Position = header.OffsetDOL;
                    destination.Write(source.ReadBytes((int)Disc.DOLLength), 0, (int)Disc.DOLLength);

                    //Aplicando PAD.
                    WritePad4(destination);
                }else
                    DOLOffset = 0;
            }
        }
    }
}
