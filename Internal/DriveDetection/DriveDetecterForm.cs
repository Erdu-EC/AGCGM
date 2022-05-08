using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Internal.DriveDetection
{

    public partial class DriveDetecterForm : Form
    {
        public DriveDetecterForm()
        {
            InitializeComponent();
        }

        //Eventos.
        internal event Action<DeviceDetected> OnDeviceDetected;
        internal event Action<DeviceDetected> OnDeviceRemoved;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            DeviceDetected detected;

            switch ((WM_Message)m.Msg)
            {
                case WM_Message.DeviceChange:
                    switch ((WM_DeviceMessage)m.WParam)
                    {
                        //Nuevo dispositivo conectado.
                        case WM_DeviceMessage.DeviceDetected:
                            detected = new DeviceDetected(m.LParam);
                            if (detected.DeviceType == WM_DeviceType.LogicalVolume)
                                OnDeviceDetected?.Invoke(detected);
                            break;

                        //Dispositivo desconectado.
                        case WM_DeviceMessage.DeviceRemoved:
                            detected = new DeviceDetected(m.LParam);
                            if (detected.DeviceType == WM_DeviceType.LogicalVolume)
                                OnDeviceRemoved?.Invoke(detected);
                            break;
                    }
                    break;
            }

        }
    }
}



