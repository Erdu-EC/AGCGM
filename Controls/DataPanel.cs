using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGCGM.Internal.IO.GC;
using AGCGM.Internal.XMLDB;
using static AGCGM.Internal.XMLDB.TDBEnums;

namespace AGCGM.Controls
{
    public partial class DataPanel : UserControl
    {
        public Image Cover { get => PPBCover.Image; set => PPBCover.Image = value; }
        public string Title { get => PLBTitle.Text; set => PLBTitle.Text = value; }
        public string Description { get => PLBDescription.Text; set => PLBDescription.Text = value; }
        public string Trimmed { get => PLBTrimmed.Text; set => PLBTrimmed.Text = value; }
        public string Languages { get => PLBLang.Text; set => PLBLang.Text = value; }

        public DataPanel() => InitializeComponent();

        public void SetRegionFlag(TDBEnums.GameRegion lang)
        {
            Image flag;

            switch (lang)
            {
                case TDBEnums.GameRegion.PAL:
                case TDBEnums.GameRegion.PAL_R:
                    flag = Properties.Resources.Flag_Europe;
                    break;
                case TDBEnums.GameRegion.NTSC_U:
                    flag = Properties.Resources.Flag_USA;
                    break;
                case TDBEnums.GameRegion.NTSC_J:
                    flag = Properties.Resources.Flag_Japan;
                    break;
                case TDBEnums.GameRegion.FREE:
                    flag = Properties.Resources.Flag_International;
                    break;
                default:
                    flag = null;
                    break;
            }

            PPBRegion.Image = flag;
        }

        public void SetRequiredControls(InputControl[] controls)
        {
            FlowRequired.Controls.Clear();
            foreach (var input in controls)
            {
                FlowRequired.Controls.Add(new PictureBox() { Image = GetInputImage(input), SizeMode = PictureBoxSizeMode.Zoom});
            }
        }

        public void SetOptionalControls(InputControl[] controls)
        {
            FlowOptional.Controls.Clear();
            foreach (var input in controls)
            {
                FlowOptional.Controls.Add(new PictureBox() { Image = GetInputImage(input), SizeMode = PictureBoxSizeMode.Zoom });
            }
        }

        private Image GetInputImage(InputControl control)
        {

            return Properties.Resources.ResourceManager.GetObject(control.ToString()) as Image;
            /*switch (control)
            {
                case InputControl.Unknown:
                    break;
                case InputControl.wiimote:
                    return Properties.Resources.wiimote;
                    break;
                case InputControl.nunchuk:
                    break;
                case InputControl.motionplus:
                    break;
                case InputControl.gamecube:
                    break;
                case InputControl.nintendods:
                    break;
                case InputControl.classiccontroller:
                    break;
                case InputControl.wheel:
                    break;
                case InputControl.zapper:
                    break;
                case InputControl.balanceboard:
                    break;
                case InputControl.wiispeak:
                    break;
                case InputControl.microphone:
                    break;
                case InputControl.guitar:
                    break;
                case InputControl.drums:
                    break;
                case InputControl.dancepad:
                    break;
                case InputControl.keyboard:
                    break;
                case InputControl.udraw:
                    break;
                default:
                    break;
            }*/
        }
    }
}
