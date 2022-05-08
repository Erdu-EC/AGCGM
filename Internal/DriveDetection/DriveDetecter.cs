using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AGCGM.Internal.DriveDetection
{ 
    //Enumeraciones.
    public enum WM_Message
    {
        DeviceChange = 0x219,
        WM_DEVICECHANGE = 0x219
    }

    public enum WM_DeviceMessage
    {
        DBT_DEVICEARRIVAL = 0x8000,
        DBT_DEVICEREMOVECOMPLETE = 0x8004,

        DeviceDetected = 0x8000,
        DeviceRemoved = 0x8004,
    }

    public enum WM_DeviceType
    {
        DBT_DEVTYP_OEM = 0, //OEM_IHVDevice
        DBT_DEVTYP_VOLUME = 2, //LogicalVolume
        DBT_DEVTYP_PORT = 3, //SerialParallelPortDevice
        DBT_DEVTYP_DEVICEINTERFACE = 5, //DeviceClass
        DBT_DEVTYP_HANDLE = 6, //FileSystemHandle

        OEM_IHVDevice = 0,
        LogicalVolume = 2,
        SerialParallelPortDevice = 3,
        DeviceClass = 5,
        FileSystemHandle = 6
    }

    //Estructuras.
    [StructLayout(LayoutKind.Sequential)]
    public struct DevBroadcastHeader
    {
        public int Size;
        public WM_DeviceType DeviceType;
        public int Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DevBroadcastVolume
    {
        public int Size;
        public WM_DeviceType DeviceType;
        public int Reserved;
        public int Mask;
        public short Flags;
    }

    internal class DeviceDetected
    {
        //Miembros privados;
        private DevBroadcastHeader Header;
        private DevBroadcastVolume Data;

        //Propiedades publicas.
        public WM_DeviceType DeviceType { get; }
        public string[] Letters { get; }

        public DeviceDetected(IntPtr LParam){
            //Obteniendo header del mensaje.
            Header = (DevBroadcastHeader)Marshal.PtrToStructure(LParam, typeof(DevBroadcastHeader));
            DeviceType = Header.DeviceType;

            if (DeviceType == WM_DeviceType.LogicalVolume)
            {
                //Obteniendo datos del mensaje.
                Data = (DevBroadcastVolume)Marshal.PtrToStructure(LParam, typeof(DevBroadcastVolume));

                //Identificando letras de unidades afectadas.
                List<string> letters = new List<string>();

                for (int letter = 'A'; letter <= 'Z'; letter++)
                {
                    int letterMask = 1 << (letter - 'A');
                    if ((letterMask & Data.Mask) == letterMask)
                        letters.Add(($"{(char)letter}:/").ToString());
                }

                Letters = letters.ToArray();
            }
        }

        public DriveInfo[] GetDrives() => Letters.Select((letter) => new DriveInfo(letter)).ToArray();
    }
}
