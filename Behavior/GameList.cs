using AGCGM.Behavior.Task;
using AGCGM.Controls;
using AGCGM.Internal.Configs;
using AGCGM.Internal.Serialize;
using AGCGM.Internal.IO;
using AGCGM.Internal.IO.GC;
using AGCGM.Internal.IO.GC.Files;
using AGCGM.Internal.Threading;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AGCGM.Behavior.Log;
using static AGCGM.Internal.IO.GC.DiskGC;
using System.Collections.Concurrent;
using Text = AGCGM.Lang.strings;
using AGCGM.Lang;
using AGCGM.Internal.DriveDetection;
using AGCGM.Controls.Page;
using AGCGM.Internal.XMLDB;
using GCGM.Controls;
using static System.Windows.Forms.Control;
using static System.Windows.Forms.ListView;

namespace AGCGM.Behavior
{
    public class GameList
    {
        //Constantes.
        public const string NOBACKUPBANNER = "nobanner";

        //Miembros privados.
        // private static Inicio Main;
        private static ImageList Banners;
        private static GameListNotify NotifyStatus;

        public static GameTabs Tabs { get; private set; }

        //Constructor.
        public GameList(Inicio main, TabPage mainPage)
        {
            Tabs = new GameTabs(main.Tabs, mainPage);

            //Inicializando banners.
            Banners = new ImageList() { ImageSize = BNR.Size };
            Banners.Images.Add(NOBACKUPBANNER, ResX.Images.nobanner);

            //Inicializando barra de estatus.
            NotifyStatus = new GameListNotify(main);
            NotifyStatus.SetButtonEvent((obj, arg) => CancelTasks()); //Controlando boton de cancelacion.

            //Iniciando escaneo inicial de directorios y dispositivos.
            new InitialScanTask(Tabs).Start();

            //Controlando evento de deteccion de dispositivos extraibles.
            main.OnDeviceDetected += DeviceDetected;
        }

        //Metodos para controlar las tareas.
        private void CancelTasks()
        {
            TaskManaged.CancelAll<AddBackupTask>();
            TaskManaged.CancelAll<AddDirectoryTask>();
        }

        //Metodos para deteccion de dispositivos extraibles.
        private void DeviceDetected(DeviceDetected device)
        {
            foreach (DriveInfo driveInfo in Drive.GetList(device.GetDrives()))
            {
                //Obteniendo datos.
                string label = Execute.Assign(() => driveInfo.VolumeLabel);
                if (label != null)
                {
                    //Obteniendo configuraciones.
                    DriveData data = Inicio.Settings.GetDrive(driveInfo.Name, label) ?? new DriveData(driveInfo.Name, label);

                    //Log.
                    AddLog(Text.LOG_DEVICE_DETECTED, LogLevel.Information, data.GetFormatedLabel());

                    //Agregando dispositivo, si es necesario.
                    if (data.Automount) AddDrive(data, false);
                }
            }
        }

        //Metodos para agregar tareas (Backups).
        public static TaskManaged[] AddGame(string[] files, GameInfo gameInfo, GamePage page)
        {
            //Inicializando barra de progreso.
            NotifyStatus.SetStatus(Text.STATUS_BACKUP_ADDING, null);
            NotifyStatus.SetProgressStyle(ProgressBarStyle.Continuous);

            //Estableciendo banner del PageGame.
            if (page.Banners is null) page.Banners = Banners;

            //Creando lista local de Task.
            List<TaskManaged> localTask = new List<TaskManaged>();

            //Si no se pasaron archivos, intentar finalizar estatus.
            if (files.Length == 0) NotifyStatus.TryFinish();
            //Si hay, agregar al maximo progreso.
            else NotifyStatus.AddMaxProgress(files.Length);

            //Abriendo base de datos de juegos.
            TDBDatabase db = Execute.Assign(() => new TDBDatabase(TDBStrings.DATABASE_NAME));

            foreach (string path in files)
            {
                //Si el archivo existe en lista.
                if (page.ContainsGame(path))
                {
                    AddLog(Text.ADD_BACKUP_EXIST_IN_TAB.FormatWith(page.Parent.Text), LogLevel.Warning, path);
                    NotifyStatus.SetStatus(Text.STATUS_BACKUP_ADDING, path);
                    NotifyStatus.AddProgress();
                    continue;
                }

                //Creando tarea.
                AddBackupTask task = new AddBackupTask(path, gameInfo, page, db);
                task.OnFinish += (obj) => //Accion final, si ocurrio o no error.
                {
                    NotifyStatus.SetStatus(Text.STATUS_BACKUP_ADDING, (obj as AddBackupTask).BackupName);
                    NotifyStatus.SetProgressStyle(ProgressBarStyle.Continuous);
                    NotifyStatus.AddProgress();
                    NotifyStatus.TryFinish();
                };

                //Iniciandola.
                localTask.Add(task);
                task.Start();
            }

            //Devolviendo tareas.
            return localTask.ToArray();
        }

        public static void AddDirectory(string path, bool subDirs, GamePage page)
        {
            //Creando pestaña si es necesario.
            if (page is null) page = Tabs.CreateTab(path).Controls[0] as GamePage;

            //Creando y lanzando tarea.
            NewAddDirectoryTask(Text.STATUS_DIRECTORY_ANALYZING, path, subDirs, page).Start();
        }

        public static void AddDrive(DriveData driveData, bool showUI)
        {
            //Realizando comprobaciones.
            if (!Drive.IsReady(driveData.Name))
            {
                string message = Text.MSG_DEVICE_UNAVAILABLE.FormatWith(driveData.GetFormatedLabel());

                AddLog(message, LogLevel.Error, driveData.Name);

                if (showUI) MessageBox.Show(message, Text.TITLE_DEVICE_MOUNT, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Drive.IsReadyForGC(driveData.Name))
            {
                string message = string.Format(Text.MSG_DEVICE_NOT_PREPARED_QUESTION, driveData.GetFormatedLabel(), driveData.GetGCRoot());

                AddLog(string.Format(Text.LOG_DEVICE_NOT_PREPARED, driveData.GetGCRoot()), LogLevel.Warning, driveData.GetFormatedLabel());

                if (showUI && MessageBox.Show(message, Text.TITLE_DEVICE_MOUNT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(driveData.GetGCRoot());
                        AddLog(Text.LOG_DEVICE_PREPARED_SUCCESS, LogLevel.Information, driveData.GetFormatedLabel());

                        //Intentandolo de nuevo.
                        AddDrive(driveData, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text.TITLE_DEVICE_MOUNT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ex.AddLog(LogLevel.Error, driveData.GetFormatedLabel());
                    }
                }
            }
            else
            {
                //Creando pestaña si es necesario.
                Drive drive = Execute.Assign(() => new Drive(driveData));
                GamePage page = Tabs.CreateTab(driveData, drive != null ? drive.Type : DriveType.Unknown).Controls[0] as GamePage;

                //Analizando y agregando dispositivo.
                NewAddDirectoryTask(Text.STATUS_DRIVE_ANALYZING, driveData.GetGCRoot(), true, page).Start();
            }
        }

        private static AddDirectoryTask NewAddDirectoryTask(string STATUS, string path, bool subDirs, GamePage page)
        {
            //Inicializando barra de progreso.
            NotifyStatus.SetStatus(STATUS, path);
            NotifyStatus.SetProgressStyle(ProgressBarStyle.Marquee);

            AddDirectoryTask task = new AddDirectoryTask(path, subDirs, page);
            task.OnSubDirectorySearch += (subdir) =>
            {
                NotifyStatus.SetStatus(STATUS, subdir);
                NotifyStatus.SetProgressStyle(ProgressBarStyle.Marquee);
            };
            task.OnFinish += (_) => NotifyStatus.TryFinish();

            return task;
        }

        public static void DownloadCovers(IEnumerable<ListViewItem> items)
        {
            if (items.Count() > 0)
            {
                var covers_disabled = Inicio.Settings.Covers.Where(cover => !cover.Enabled);

                //Comprobando e informando si es necesario descargar caratulas.
                if (covers_disabled.Count() == Inicio.Settings.Covers.Count)
                    AddLog($"No se descargara ningun tipo de caratula, tal y como se indica en las configuraciones.", LogLevel.Warning);

                //Informando los tipos de caratulas que no se descargaran.
                foreach (var cover in covers_disabled)
                    AddLog($"Las caratulas de tipo \"{cover.Type}\" no seran descargadas, tal y como se indica en las configuraciones.", LogLevel.Warning);

                //Iniciando descarga de cada caratula.
                Inicio.SidePanel.DownloadPanel.SuspendLayout();
                foreach (ListViewItem item in items) DownloadCover(item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[6].Text);
                Inicio.SidePanel.CollapseDownloadPanel(false);
                Inicio.SidePanel.DownloadPanel.ResumeLayout(true);
            }
        }

        public static void DownloadCover(string gameCode, string gameName, string fileName)
        {
            lock (TaskManaged.RunningTasks)
            {
                if (TaskManaged.RunningTasks.OfType<DownloadTask>().Where(task => task.BackupCode == gameCode).Count() > 0)
                {
                    AddLog(Text.TASK_DOWNLOAD_COVER_EXIST.FormatWith(gameName), LogLevel.Warning, fileName);
                    return;
                }
            }

            if (GameCover.ExistAll(gameCode))
            {
                AddLog(Text.TASK_DOWNLOAD_ALL_COVERS_EXIST.FormatWith(gameName), LogLevel.Warning, fileName);
                return;
            }

            //Lanzando  hilos de descarga.
            (new DownloadTask(Inicio.SidePanel.AddDownloadItem(gameCode, gameName), gameCode, fileName) as DownloadTask).Start();
        }

        public static void TransferTo(GamePage sourcePage, GamePage destPage, SelectedListViewItemCollection items, bool trim)
        {
            //Si el origen y destino son validos.
            if (IsValidPage(sourcePage, "Error al transferir") && IsValidPage(destPage, "Error al transferir"))
            {
                //Datos origen.
                string sourcePath = sourcePage.SourcePath;
                string sourceDir = Path.GetDirectoryName(sourcePath);

                //Recorriendo seleccionados.
                foreach (ListViewItem item in items)
                {
                    GCHeader discHeader = null;

                    //Datos de ruta origen.
                    string filepath = item.SubItems[6].Text;
                    string filename = Path.GetFileName(filepath);
                    string filedir = Path.GetDirectoryName(filepath);

                    if (!File.Exists(filepath))
                    {
                        string message = $"El archivo \"{filepath}\" no esta disponible, puede que este haya sido movido o eliminado.";
                        AddLog(message, LogLevel.Warning, filepath);

                        MessageBox.Show(message, "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    try
                    {
                        //Abriendo archivo fuente para obtener sus datos de disco.
                        using (Stream stream = File.OpenRead(filepath))
                            discHeader = new GCHeader(new BinaryReader(stream));
                    }
                    catch (Exception ex)
                    {
                        ex.AddLog(LogLevel.Warning, filepath);
                        continue;
                    }

                    //Datos de ruta destino.
                    //Corrigiendo nombre del juego.
                    string game_name_fix = item.SubItems[2].Text.Replace(":", " - ");
                    Array.ForEach(Path.GetInvalidPathChars().Union(Path.GetInvalidFileNameChars()).ToArray(), (car) => game_name_fix = game_name_fix.Replace(car.ToString(), ""));

                    //Datos de ruta destino.
                    string dest_filedir = Path.Combine(destPage.DriveData?.GetGCRoot() ?? destPage.SourcePath, $"{game_name_fix} [{discHeader.FullCode}]");
                    string dest_filename = discHeader.DiskID == 0 ? "game.iso" : "Disc2.iso";
                    string dest_filepath = Path.Combine(dest_filedir, dest_filename);

                    //Verificando que el origen y destino no sean el mismo.
                    if (filepath == dest_filepath)
                    {
                        string message = $"El origen y el destino son el mismo.\n\nOrigen: {filepath}\nDestino: {dest_filepath}";
                        AddLog(message, LogLevel.Warning, $"{filepath} => {dest_filepath}");

                        MessageBox.Show(message, $"Transferir a {destPage.DriveData?.GetFormatedLabel() ?? Path.GetFileName(dest_filedir)}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    //Verificando si existe una transferencia en progreso para ese archivo destino.
                    if (Inicio.SidePanel.ExistTransferInProgress(dest_filepath))
                    {
                        string message = $"Ya existe una tranferencia en progreso para el archivo de destino \"{dest_filepath}\".";
                        AddLog(message, LogLevel.Warning, $"{filepath} => {dest_filepath}");

                        MessageBox.Show(message, $"Transferir a {destPage.DriveData?.GetFormatedLabel() ?? Path.GetFileName(dest_filedir)}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    //Verificando si existe un archivo con ese nombre en el destino.
                    if (File.Exists(dest_filepath))
                    {
                        bool validDisc = true;

                        //Abriendo archivo para verificar si es un Backup valido.
                        try
                        {
                            //Abriendo archivo para verificar si el destino es un backup gamecube valido.
                            using (Stream stream = File.OpenRead(dest_filepath))
                                new GCHeader(new BinaryReader(stream));
                        }
                        catch (GCException ex)
                        {
                            ex.AddLog(LogLevel.Warning, dest_filepath);
                            validDisc = false;
                        }
                        catch (Exception ex)
                        {
                            ex.AddLog(LogLevel.Warning, dest_filepath);
                        }

                        string message = $"Ya existe un archivo llamado \"{dest_filename}\" en el directorio \"{dest_filedir}\".";
                        string invalidMessage = "\n\nEl cual no es un backup de juego GameCube valido o esta dañado.";
                        AddLog(message + (validDisc ? "" : invalidMessage), LogLevel.Warning, dest_filepath);

                        var result = MessageBox.Show(message + (validDisc ? "" : invalidMessage) + "\n\n¿Desea sobreescribirlo?", $"Transferir a {destPage.DriveData?.GetFormatedLabel() ?? Path.GetFileName(dest_filedir)}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No) continue;
                    }

                    //Comprobando si existe directorio destino, si no crearlo.
                    if (!Directory.Exists(dest_filedir))
                    {
                        try
                        {
                            Directory.CreateDirectory(dest_filedir);
                        }
                        catch (Exception ex)
                        {
                            ex.AddLog(LogLevel.Error, dest_filedir);
                            continue;
                        }
                    }

                    //Obteniendo banner del juego.
                    Image banner = sourcePage.Banners.Images[item.ImageKey];

                    TransferItem transferItem = Inicio.SidePanel.AddTransferItem(sourcePage.SourcePath, filepath, sourcePage.Parent.Text, destPage.SourcePath, dest_filepath, destPage.Parent.Text, banner, item.SubItems[2].Text);

                    //Lanzando hilo de transferencia.
                    new TransferTask(transferItem, trim).Start();

                    //Mostrando panel.
                    Inicio.SidePanel.CollapseTransferPanel(false);
                }
            }
            else
                AddLog("Tranferencia cancelada.", LogLevel.Error, $"{sourcePage.SourcePath} => {destPage.SourcePath}");
        }

        public static bool IsValidPage(GamePage locationPage, string title)
        {
            if (locationPage.Parent == Tabs.MainPage) return true;

            if (locationPage.DriveData is null)
            {
                //Si el directorio no existe.
                if (!Directory.Exists(locationPage.SourcePath))
                {
                    string message = $"El directorio \"{locationPage.SourcePath}\" no esta disponible, puede que este haya sido movido o eliminado.";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddLog(message, LogLevel.Error, locationPage.SourcePath);
                    return false;
                }
            }
            else
            {
                //Obteniendo información del dispositivo.
                Drive drive = Execute.Assign(() => new Drive(locationPage.DriveData));

                //Si el dispositivo no esta listo.
                if (drive is null || !drive.IsReadyForGC())
                {
                    string message = $"El dispositivo \"{locationPage.DriveData.GetFormatedLabel()}\" no esta disponible.";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddLog(message, LogLevel.Error, locationPage.DriveData.GetGCRoot());
                    return false;
                }
            }

            return true;
        }
    }

    public class GameListDialog
    {
        private static FileDialog FileDialog;
        private static FolderBrowserDialog DirectoryDialog;

        public static void SelectGame(GamePage page)
        {
            if (FileDialog is null)
            {
                //Generando filtro.
                string filter = "";
                for (int i = 0; i < Extensions.Length; i++)
                    filter += $"{ExtensionDescriptions[i]}|*{Extensions[i]}|";
                filter += Text.ALL_FILES + "|*.*";

                //Creando dialogo.
                FileDialog = new OpenFileDialog
                {
                    Title = Text.ADD_SELECT_GAME,
                    Filter = filter,
                    AddExtension = false,
                    ValidateNames = true,
                    CheckFileExists = true,
                    CheckPathExists = true,
                    RestoreDirectory = true,
                    Multiselect = true
                };

                //Controlando evento OK.
                FileDialog.FileOk += (obj, arg) => GameList.AddGame(FileDialog.FileNames, null, page);
            }

            //Mostrando dialogo.
            FileDialog.ShowDialog();
        }

        public static void SelectDirectory(bool searchInSubDirs, GamePage page)
        {
            if (DirectoryDialog is null)
            {
                DirectoryDialog = new FolderBrowserDialog()
                {
                    Description = Text.ADD_SELECT_DIRECTORY,
                    RootFolder = Environment.SpecialFolder.MyComputer,
                    ShowNewFolderButton = false
                };
            }

            if (DirectoryDialog.ShowDialog() == DialogResult.OK)
                GameList.AddDirectory(DirectoryDialog.SelectedPath, searchInSubDirs, page);
        }
    }

    internal class GameListNotify
    {
        private readonly Inicio Main;
        private readonly ToolStripStatusLabel StatusLabel;
        private readonly ToolStripStatusLabel StatusFile;
        private readonly ToolStripProgressBar StatusProgress;
        private readonly ToolStripStatusLabel StatusButton;

        private static DateTime NotifyLastTime;
        int GamesAdded = 0;
        int GamesAdding = 0;

        public GameListNotify(Inicio main)
        {
            Main = main;
            StatusLabel = main.StatusLabel;
            StatusFile = main.StatusFile;
            StatusProgress = main.StatusProgress;
            StatusButton = main.StatusButton;
            NotifyLastTime = DateTime.Now;
        }

        public void SetButtonEvent(EventHandler action) => StatusButton.Click += action;

        public void SetStatus(string status, string file)
        {
            if (NotifyLastTime.AddMilliseconds(100) < DateTime.Now)
            {
                Execute.RunForeground(Main, () =>
                {
                    StatusLabel.Text = status;
                    StatusFile.Text = file;

                    if (!StatusProgress.Visible) SetVisible(true);
                });
            }
        }

        public void SetProgressStyle(ProgressBarStyle style)
        {
            Execute.RunForeground(Main, () =>
            {
                if (StatusProgress.Style != style)
                    StatusProgress.Style = style;
            });
        }

        private void SetVisible(bool visible)
        {
            Execute.RunForeground(Main, () =>
            {
                StatusFile.Visible = visible;
                StatusButton.Visible = visible;
                StatusProgress.Visible = visible;
            });
        }

        private void Reset()
        {
            Execute.RunForeground(Main, () =>
            {
                GamesAdded = GamesAdding = 0;
                StatusLabel.Text = Text.READY_POINT;
                StatusFile.Text = null;
                StatusProgress.Value = 0;
                SetVisible(false);
            });
        }

        public void AddProgress()
        {
            Execute.RunForeground(Main, () =>
            {
                lock (StatusProgress)
                {
                    GamesAdded++;

                    int percentege = Calc.Percentage(GamesAdded, GamesAdding);
                    if (percentege != StatusProgress.Value)
                        StatusProgress.Value = percentege;
                }
            });
        }

        public void AddMaxProgress(int items)
        {
            GamesAdding += items;
        }

        public void TryFinish()
        {
            if (GamesAdding == 0 || StatusProgress.Value >= StatusProgress.Maximum)
                Reset();
        }
    }
}
