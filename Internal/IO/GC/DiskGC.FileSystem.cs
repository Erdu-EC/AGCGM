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
        public class GCFileSystem
        {
            //Constantes privadas
            private const int sizeEntry = 12; //Bytes

            //Propiedades.
            public FSDirectory Root { get; }
            public FSEntry[] Entries { get; }
            public uint OffsetFST { get; }
            public int LengthFST { get; }

            //Propiedades privadas.
            private uint OffsetStr { get; }
            private int LengthStr { get; }

            //Metodos calculados.
            public int GetTrimLength(int newOffsetFST) => GetTrimEntries((uint)newOffsetFST).OfType<FSFile>().Sum((entry) => entry.Length);

            //Contructor.
            public GCFileSystem(BinaryReader reader, uint offset, int size)
            {
                //Verificando tamaño del sistema de archivos.
                if (reader.BaseStream.Length < offset + size)
                    throw new GCException("Imposible leer el sistema de archivos, el tamaño del Backup es muy pequeño.");

                //Leyendo tabla de ficheros del sistema de archivos.
                //fst.bin -> (offset, offset + size)

                //Leyendo cantidad de subentradas del directorio root.
                reader.BaseStream.Position = offset + 8;                // . . .
                int num_entries = reader.ReadBytes(4).ToInt();          //Offset = 8 : Size = 4

                //Creando directorio root.
                Root = new FSDirectory(index: 0, nextIndex: num_entries, offsetName: 0, name: "\\", parent: null);

                //Estableciendo propiedades.
                OffsetFST = offset;                                     //Posicion del FST
                OffsetStr = offset + (uint)(num_entries * sizeEntry);   //Posicion de la tabla de nombres.
                LengthFST = size;                                       //Tamaño del FST
                LengthStr = (int)(OffsetFST + LengthFST - OffsetStr);   //Tamaño de la tabla de nombres

                //Obteniendo tabla de nombres.
                reader.BaseStream.Position = OffsetStr;
                string names = new string(reader.ReadChars(LengthStr));

                //Inicializando lista de entradas del FS;
                Dictionary<int, FSEntry> ReadyEntries = new Dictionary<int, FSEntry>
                {
                    { 0, Root } //Agregando Root;
                };

                //Contruyendo estructura del FS.
                MakeFileSystem(reader, names, 1, Root.NextIndex, Root, ReadyEntries);

                //Almacenando array de entradas del FS;
                Entries = ReadyEntries.OrderBy((entry) => entry.Key).Select((entry) => entry.Value).ToArray();
            }

            //Metodos privado para inicializar el sistema de archivos.
            private void MakeFileSystem(BinaryReader reader, string StrTable, int StartIndex, uint EndIndex, FSDirectory Parent, Dictionary<int, FSEntry> ReadyEntries)
            {
                //Calculando el desplazamiento de la entrada actual.
                reader.BaseStream.Position = OffsetFST + (StartIndex * sizeEntry);

                //Recorriendo las entradas.
                for (int index = StartIndex; index < EndIndex; index++)
                {
                    //Si la entrada ya existe, ignorarla
                    if (ReadyEntries.ContainsKey(index)) continue;

                    //Leyendo campos
                    int IsDir = reader.ReadByte();                          //Offset = 0 : Size = 1
                    int offsetName = reader.ReadBytes(3).ToInt();           //Offset = 1 : Size = 3
                    int offsetFile_parentDir = reader.ReadBytes(4).ToInt(); //Offset = 4 : Size = 4
                    int lengthFile_nextDir = reader.ReadBytes(4).ToInt();   //Offset = 8 : Size = 4

                    //Obteniendo nombre de la tabla de strings.
                    string name = StrTable.Substring(offsetName, StrTable.IndexOf('\0', offsetName) - offsetName);

                    //Determinando y creando entrada.
                    FSEntry Entry;

                    if (IsDir == 1)
                    {
                        //Creando directorio.
                        FSDirectory directory = new FSDirectory(index, lengthFile_nextDir, offsetName, name, Parent);
                        Entry = directory;

                        //Recorriendo sus ficheros y subdirectorios.
                        MakeFileSystem(reader, StrTable, index + 1, directory.NextIndex, directory, ReadyEntries);
                    }
                    else
                    {
                        //Creando fichero.
                        Entry = new FSFile(index, offsetFile_parentDir, lengthFile_nextDir, offsetName, name, Parent);
                    }

                    //Agregando a la lista de entradas existentes.
                    ReadyEntries.Add(index, Entry);
                }
            }

            private FSEntry[] GetTrimEntries(uint newOffsetFST)
            {
                long offset = Pad4(newOffsetFST + LengthFST);
                List<FSEntry> Entries = new List<FSEntry>();

                foreach (FSEntry entry in this.Entries)
                {
                    FSEntry newEntry = entry.Clone(entry.Parent != null ? Entries[(int)entry.Parent.Index] as FSDirectory : null);
                    if (newEntry is FSFile)
                    {
                        (newEntry as FSFile).Offset = (int)offset;
                        offset = Pad4(offset + (newEntry as FSFile).Length);
                    }

                    Entries.Add(newEntry);
                }

                return Entries.ToArray();
            }

            //Metodos publicos de operaciones.
            public FSFile GetFileEntry(string path)
            {
                var result = Entries.OfType<FSFile>().Where((entry) => entry.Path == path).AsParallel();
                return result.Count() > 0 ? result.First() : null;
            }

            public void Write(BinaryReader source, Stream destination, uint newOffsetFST, bool trim, Action<long> reportBytesWrited, Func<bool> hasRequestedCancel, FSFile dolFile, out uint DOLOffset)
            {
                DOLOffset = 0;

                //Estableciendo posiciones.
                source.BaseStream.Position = OffsetStr;
                destination.Position = newOffsetFST;

                //Obteniendo FST trim.
                FSEntry[] TrimEntries = trim? GetTrimEntries(newOffsetFST) : Entries;

                //Copiando TrimFST.
                foreach (FSEntry entry in TrimEntries)
                {
                    destination.Write(entry.ToBytes(), 0, sizeEntry);

                    //Si el DOL existe en el sistema de ficheros.
                    if (dolFile != null && dolFile.Index == entry.Index && dolFile.Path == entry.Path)
                        DOLOffset = (uint)(entry as FSFile).Offset;
                }

                //Copiando tabla de strings.
                destination.Write(source.ReadBytes(LengthStr), 0, LengthStr);

                //var esult = Entries.Where(entry => !(entry is FSDirectory)).Select(entry => entry as FSFile).ToArray().OrderBy(entry => entry.Offset).First();

                //Verificando cancelacion.
                if (hasRequestedCancel != null && hasRequestedCancel()) return;

                //Notificando progreso (Bytes escritos en el FST y la tabla de strings).
                long offset = Pad4(newOffsetFST + LengthFST);
                reportBytesWrited?.Invoke(offset - newOffsetFST);

                //Escribiendo ficheros.
                for (int index = 0; index < Entries.Length; index++)
                {
                    if (Entries[index] is FSDirectory) continue;

                    //Verificando cancelacion.
                    if (hasRequestedCancel != null && hasRequestedCancel()) return;

                    //Cambiando tipos.
                    FSFile file = Entries[index] as FSFile;
                    FSFile trimFile = TrimEntries[index] as FSFile;

                    //Estableciendo posicion del fichero.
                    source.BaseStream.Position = file.Offset;
                    destination.Position = trimFile.Offset;

                    //Escribiendo fichero.
                    destination.Write(source.ReadBytes(file.Length), 0, file.Length);

                    //Notificando progreso (Bytes escritos en cada fichero).
                    reportBytesWrited?.Invoke(Pad4(offset + file.Length) - offset);

                    //Offset del proximo archivo.
                    offset = Pad4(offset + file.Length);
                }
            }  
        }

        public abstract class FSEntry
        {
            public uint Index { get; }
            public string Name { get; }
            public uint OffsetName { get; }
            public FSDirectory Parent { get; }

            public string Path => Parent is null ? Name : System.IO.Path.Combine(Parent.Path, Name);

            public FSEntry(int index, int OffsetName, string Name, FSDirectory Parent)
            {
                Index = (uint)index;
                this.OffsetName = (uint)OffsetName;
                this.Name = Name;
                if ((this.Parent = Parent) != null) Parent.Items.Add(this);
            }

            public int IsDirectory() => this is FSDirectory ? 1 : 0;

            public byte[] ToBytes()
            {
                //Creando lista de bytes
                List<byte> data = new List<byte>
                {
                    (byte)IsDirectory()    //¿Es un directorio?
                };

                data.AddRange(OffsetName.ToBytes(3));    //Nombre del directorio o fichero

                if (IsDirectory() == 1)
                {
                    data.AddRange(((FSDirectory)this).Parent?.Index.ToBytes(4) ?? 0.ToBytes(4)); //Index del directorio padre
                    data.AddRange(((FSDirectory)this).NextIndex.ToBytes(4));   //Index de la carpeta siguiente (¿Hermana?)
                }
                else
                {
                    data.AddRange(((FSFile)this).Offset.ToBytes(4)); //Posicion del fichero
                    data.AddRange(((FSFile)this).Length.ToBytes(4)); //Tamaño del fichero
                }

                //Devolviendo bytes
                return data.ToArray();
            }

            public abstract FSEntry Clone(FSDirectory Parent);
        }

        public class FSDirectory : FSEntry
        {
            public uint NextIndex { get; }
            public List<FSEntry> Items { get; }

            public FSDirectory(int index, int nextIndex, int offsetName, string name, FSDirectory parent) : base(index, offsetName, name, parent)
            {
                NextIndex = (uint)nextIndex;
                Items = new List<FSEntry>();
            }

            public override FSEntry Clone(FSDirectory Parent)
            {
                return new FSDirectory((int)Index, (int)NextIndex, (int)OffsetName, Name, Parent);
            }
        }

        public class FSFile : FSEntry
        {
            //Propiedades
            public int Offset { get; set; }
            public int Length { get; }

            //Contructor.
            public FSFile(int index, int offsetFile, int lengthFile, int offsetName, string name, FSDirectory parent = null) : base(index, offsetName, name, parent)
            {
                Offset = offsetFile;
                Length = lengthFile;
            }

            public override FSEntry Clone(FSDirectory Parent)
            {
                return new FSFile((int)Index, Offset, Length, (int)OffsetName, Name, Parent);
            }
        }
    }
}
