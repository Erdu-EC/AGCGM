using AGCGM.Internal.Configs;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.IO
{
    public class Drive
    {
        //Constructor.
        public Drive(DriveInfo drive) => Initialize(drive);
        public Drive(DriveData data) => Initialize(new DriveInfo(data.Name));

        //Inicializacion.
        private void Initialize(DriveInfo drive)
        {
            Label = drive.VolumeLabel;
            Format = drive.DriveFormat;
            FreeSpace = drive.AvailableFreeSpace;
            TotalSpace = drive.TotalSize;
            Info = drive;
        }

        //Campos privados.
        DriveInfo Info;

        //Propiedades
        public string Name { get => Info.Name; }
        public string Label { get; private set; }
        public string Format { get; private set; }
        public long FreeSpace { get; private set; }
        public long TotalSpace { get; private set; }
        public DriveType Type { get => Info.DriveType; }

        //Propiedades calculadas.
        public long UsedSpace => TotalSpace - FreeSpace;

        //Metodos para obtener datos.
        public string GetTotalSize() => DataSize.ToString(TotalSpace);
        public string GetFreeSpace() => DataSize.ToString(FreeSpace);
        public string GetUsedSpace() => DataSize.ToString(UsedSpace);

        //Metodos para comprobaciones.
        public bool IsReady() => Info.IsReady;
        public bool IsReadyForGC() => IsReadyForGC(Info);
        public bool IsReadyForWii() => IsReadyForWii(Info);
        public bool CreateGCRoot() => CreateGCRoot(Name);
        public bool CreateWiiRoot() => CreateWiiRoot(Name);

        //Metodos estaticos.
        public static DriveInfo[] GetList()
        {
            return GetList(DriveInfo.GetDrives());
        }

        public static DriveInfo[] GetList(DriveInfo[] drives)
        {
            return drives.Where((drive) =>
                drive.IsReady && (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
            ).AsParallel().ToArray();
        }

        public static bool IsReady(string name) => new DriveInfo(name).IsReady;
        public static bool IsReadyForGC(string name) => IsReadyForGC(new DriveInfo(name));
        public static bool IsReadyForWii(string name) => IsReadyForWii(new DriveInfo(name));
        public static bool IsReadyForGC(DriveInfo info) => info.IsReady && Directory.Exists(DriveData.GetGCRoot(info.Name));
        public static bool IsReadyForWii(DriveInfo info) => info.IsReady && Directory.Exists(DriveData.GetWiiRoot(info.Name));

        public static bool CreateGCRoot(string name) => Execute.Run(() => Directory.CreateDirectory(DriveData.GetGCRoot(name)));
        public static bool CreateWiiRoot(string name) => Execute.Run(() => Directory.CreateDirectory(DriveData.GetWiiRoot(name)));
    }
}
