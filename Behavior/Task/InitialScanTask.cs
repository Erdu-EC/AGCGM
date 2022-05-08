using AGCGM.Controls;
using AGCGM.Controls.Page;
using AGCGM.Internal.Configs;
using AGCGM.Internal.IO;
using AGCGM.Internal.Threading;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Behavior.Task
{
    class InitialScanTask : TaskManaged
    {
        private readonly Settings Settings = Inicio.Settings;
        private readonly GameTabs Tabs;

        public InitialScanTask(GameTabs tabs) => Tabs = tabs;

        protected override void Run()
        {
            ScansDirectory();
            ScansDrive();
        }

        private void ScansDirectory()
        {
            //Recorriendo entradas activas.
            foreach (DirectoryData directory in Settings.Directories.Where((entry) => entry.Active))
            {
                //Verificando si es necesario cancelar.
                if (IsCancelRequested) ThrowCancellationException();

                //Realizando comprobaciones.
                if (!Directory.Exists(directory.Path))
                {
                    Log.AddLog(Lang.strings.DIRECTORY_MOVED_OR_DELETED_POINT, Log.LogLevel.Warning, directory.Path);
                    return;
                }

                //Creando pestaña.
                TabPage tab = directory.NewTab ? Tabs.CreateTab(directory.Path) : Tabs.MainPage;

                //Obteniendo GamePage.
                GamePage page = tab.Controls[0] as GamePage;

                //Agregando a lista.
                GameList.AddDirectory(directory.Path, Settings.SubDirectories, page);
            }
        }

        private void ScansDrive()
        {
            //Obteniendo lista de dispositivos.
            DriveInfo[] drives = Execute.Assign(() => Drive.GetList());
            if (drives != null)
            {
                foreach (DriveInfo driveInfo in drives.Where((entry) => entry.IsReady))
                {
                    //Verificando si es necesario cancelar.
                    if (IsCancelRequested) ThrowCancellationException();

                    //Obteniendo dispositivo.
                    Drive drive = Execute.Assign(() => new Drive(driveInfo));
                    if (drive is null) continue;

                    //Obteniendo configuraciones.
                    DriveData data = Settings.GetDrive(drive) ?? new DriveData(drive);

                    //Agregando dispositivos si es necesario.
                    if (data.Automount) GameList.AddDrive(data, false);

                }
            }
        }
    }
}
