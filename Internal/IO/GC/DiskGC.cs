using AGCGM.Internal.IO.GC.Files;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.IO.GC
{
    public partial class DiskGC : IDisposable
    {
        //Miembros estaticos.
        public static string[] Extensions { get; } = { ".iso", ".gcm" };
        public static string[] ExtensionDescriptions { get; } = { "Imagen de disco", "Backup de juego Gamecube" };

        //Constantes.
        const long ORIGINAL_LENGTH = /*1459978240*/ 1459978240;

        //Miembros privados.
        private string FileName;

        private FileStream Stream;
        private readonly Encoding GeneralEncoding = Encoding.UTF7;

        //Propiedades.
        public GCHeader Header { get; private set; }
        public GCLoader Loader { get; private set; }
        public GCFileSystem FileSystem { get; private set; }

        public long DOLLength { get; private set; }

        //Metodos calculados.
        public long GetLength()
        {
            long length = GCHeader.Length;                                  //Header Size
            length = Pad4(length + Loader.Length);                          //Loader Size
            length = Pad4(length + DOLLength);                              //DOL Size
            length = Pad4(length + FileSystem.GetTrimLength((int)length));  //Files Size
            return Pad4(length + Header.LengthFST);                         //FST Size
        }

        //Constructor y destructor.
        public DiskGC(string filename) => InitializeDisk(File.OpenRead(filename), null);

        public DiskGC(FileStream stream, GCHeader header) => InitializeDisk(stream, header);

        ~DiskGC() => Dispose();

        public void Dispose()
        {
            Stream.Close();
            Stream.Dispose();
        }

        //Metodos publicos de operaciones
        public void Trim(string path, Action<int> progress, Func<bool> cancel)
        {
            long total = GetLength();
            long current = 0;

            void NotifyProgress(long bytesWrited)
            {
                //Sumando bytes escritos.
                current += bytesWrited;

                //Notificando progreso.
                progress?.Invoke(Calc.Percentage(current, total));
            }

            bool IfNeedCancel()
            {
                if (cancel != null)
                    return cancel();
                return false;
            }

            //Creando nueva imagen de disco
            using (FileStream newStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryReader sourceReader = new BinaryReader(Stream, GeneralEncoding);

                //Escribiendo cargador y DOL tal cual.
                Loader.Write(sourceReader, newStream, Header, out uint DOLOffset, out FSFile sourceDOLFile, true); //Offset = 9280 : Size = ?

                //Comprobando si es necesario cancelar.
                if (IfNeedCancel()) return;

                //Notificando progreso (Calculando bytes escritos en el loader y dol).
                NotifyProgress(newStream.Position - GCHeader.Length);

                //Determinando nuevo offset de FST.
                uint FSTOffset = (uint)newStream.Position;

                //Escribiendo sistema de archivos.
                FileSystem.Write(sourceReader, newStream, FSTOffset, true, NotifyProgress, cancel, sourceDOLFile, out uint trimDOLOffset);

                //Escribiendo cabecera con modificaciones.
                Header.Write(sourceReader, newStream, sourceDOLFile is null ? DOLOffset : trimDOLOffset, FSTOffset); //Offset = 0 : Size: 9280

                //Notificando progreso (Calculando bytes escritos en la cabecera).
                NotifyProgress(GCHeader.Length);
            }
        }

        public void Copy(string path, Action<int> progress, Func<bool> cancel)
        {
            long total = 0;
            long current = 0;

            void NotifyProgress(long bytesWrited)
            {
                //Sumando bytes escritos.
                current += bytesWrited;

                //Notificando progreso.
                progress?.Invoke(Calc.Percentage(current, total));
            }

            bool IfNeedCancel()
            {
                if (cancel != null)
                    return cancel();
                return false;
            }

            //Creando nueva imagen de disco
            using (FileStream newStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryReader sourceReader = new BinaryReader(Stream, GeneralEncoding);

                //Total.
                total = Stream.Length;

                //Escribiendo cabecera intacta.
                Header.Write(sourceReader, newStream, Header.OffsetDOL, Header.OffsetFST); //Offset = 0 : Size: 9280

                //Comprobando si es necesario cancelar.
                if (IfNeedCancel()) return;

                //Notificando progreso (Calculando bytes escritos en la cabecera).
                NotifyProgress(newStream.Position);

                //Escribiendo cargador y DOL tal cual.
                Loader.Write(sourceReader, newStream, Header, out uint _, out FSFile _, false); //Offset = 9280 : Size = ?

                //Comprobando si es necesario cancelar.
                if (IfNeedCancel()) return;

                //Notificando progreso (Calculando bytes escritos en el loader y dol).
                NotifyProgress(newStream.Position - current);

                //Escribiendo sistema de archivos.
                FileSystem.Write(sourceReader, newStream, Header.OffsetFST, false, NotifyProgress, cancel, null, out uint _);

                //Estableciendo tamaño original.
                newStream.SetLength(ORIGINAL_LENGTH);

                //Notificando progreso (Calculando bytes escritos en el loader y dol).
                current = ORIGINAL_LENGTH;
                NotifyProgress(0);
            }
        }

        //Metodos publicos para obtener archivos.
        public BNR GetBNR(Image cacheBanner)
        {
            byte[] data = GetFileBytes(@"\opening.bnr");
            return (data != null) ? new BNR(data, Header.CountryCode, cacheBanner) : null;
        }

        public byte[] GetFileBytes(string path)
        {
            FSFile entry = FileSystem.GetFileEntry(path);
            byte[] data = null;

            if (entry != null)
            {
                Execute.Run(() =>
                {
                    data = new byte[entry.Length];
                    Stream.Position = entry.Offset;
                    if (Stream.Read(data, 0, entry.Length) != entry.Length)
                        data = null;
                });
            }

            return data;
        }

        //Metodo privado de inicializacion.
        private void InitializeDisk(FileStream stream, GCHeader header)
        {
            //Estableciendo stream.
            Stream = stream;

            //Verificando tamaño de la imagen
            if (Stream.Length > ORIGINAL_LENGTH) //1.5 GB
                throw new InvalidDiskException("El tamaño del Backup GC no puede ser mayor a 1.5 GB.");

            //Obteniendo reader.
            BinaryReader reader = new BinaryReader(Stream, GeneralEncoding);

            //Obteniendo Header.
            //boot.bin (0 -> 1087) y bi2.bin (1088 -> 9279)
            Header = header is null ? new GCHeader(reader) : header;

            //Calculando tamaño del DOL.
            //bootfile -> (Header.OffsetDOL -> Header.SizeDOL())
            DOLLength = GetDOLLength(reader);

            //Obteniendo AppLoader.
            //appldr.bin -> (9280 -> ???)
            Loader = new GCLoader(this, reader);

            //Obteniendo Sistema de archivos.
            //fst.bin -> (Header.OffsetFST, Header.OffsetFST + Header.SizeFST)
            FileSystem = new GCFileSystem(reader, Header.OffsetFST, Header.LengthFST);
        }

        public FSFile GetDOLIfExistInFS()
        {
            //Comprobando si el dol existe en el sistema de ficheros del disco.
            var DOLs = FileSystem.Entries.OfType<FSFile>().Where((entry) => entry.Offset == Header.OffsetDOL && entry.Length == DOLLength);

            //Si existe, recorremos cada posible coincidencia y comparamos exahustivamente cada byte.
            foreach(FSFile dolEntry in DOLs)
            {
                //Obteniendo dol señalado en cabecera.
                Stream.Position = Header.OffsetDOL;
                byte[] dol = new byte[DOLLength];
                Stream.Read(dol, 0, dol.Length);

                //Comparandolo con la posible coincidencia en el FS.
                if (dol.SequenceEqual(GetFileBytes(dolEntry.Path)))
                    return dolEntry; //Si es exactamente igual, devolver.
            }

            return null;
        }

        private long GetDOLLength(BinaryReader reader)
        {
            uint size = 0;

            //Recorriendo las 7 secciones de codigo,y las 11 secciones de datos en busca de la ultima seccion del DOL.
            for (uint i = 0; i < 18; i++)
            {
                //Obteniendo offset de seccion, valor relativo al inicio del dol incluyendo su cabecera.
                reader.BaseStream.Position = Header.OffsetDOL + (i * 4);
                uint offset = (uint)reader.ReadBytes(4).ToInt();

                //Obteniendo length de la seccion.
                reader.BaseStream.Position = Header.OffsetDOL + 0x090 + (i * 4);
                uint length = (uint)reader.ReadBytes(4).ToInt();

                if (offset <= 0 || length <= 0)
                    continue;

                //Verificando si esta es la seccion con el offset mas alto, y
                //si lo es, entonces la suma de su offset y length podrian ser
                //el tamaño del dol, si resultara que esta es la ultima seccion
                //del dol en cuanto posicion.
                size = Math.Max(offset + length, size);
            }

            return size;
        }

        //Metodos privados de utilidades.
        private static long Pad4(long offset)
        {
            while ((offset % 4) > 0) offset++;
            return offset;
        }

        private static long WritePad4(Stream stream)
        {
            long offset = 0;
            while ((stream.Position % 4) > 0)
            {
                stream.WriteByte(0);
                offset++;
            }
            return offset;
        }

        private static long WritePadN(Stream stream, int pad)
        {
            long offset = 0;
            while ((stream.Position % pad) > 0)
            {
                stream.WriteByte(0);
                offset++;
            }
            return offset;
        }
    }


}
