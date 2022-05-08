using AGCGM.Controls;
using AGCGM.Internal.Serialize;
using AGCGM.Internal.IO.GC;
using AGCGM.Internal.Threading;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AGCGM.Behavior.Log;
using AGCGM.Lang;
using AGCGM.Controls.Page;

namespace AGCGM.Behavior.Task
{
    class AddDirectoryTask : TaskManaged
    {
        //Eventos.
        public event Action<string> OnSubDirectorySearch;

        //Miembros de instancia.
        public string Path { get; }
        public GamePage Page { get; }
        private bool SubDirectorySearch { get; }

        public AddDirectoryTask(string path, bool subDirs, GamePage page)
        {
            Path = path;
            Page = page;
            SubDirectorySearch = subDirs;

            OnFinishError += AddDirectoryException;
            OnFinishCancel += AddDirectoryCancel;
        }

        protected override void Run() => AddDirectory();

        private void AddDirectory()
        {
            //Obteniendo GameInfo.
            GameInfo gameInfo = GameInfo.Load(Path);

            //Notificando inicio de la operación.
            AddLog(gameInfo.Games.Count == 0 ?
                strings.TASK_ADDDIRECTORY_START : strings.TASK_ADDDIRECTORY_START_WITH_FILE.FormatWith(GameInfo.XMLFileName),
                LogLevel.Information, Path
            );

            //Buscando backups en el directorio y subdirectorios.
            TaskManaged[] TaskList = GameList.AddGame(GetFiles(Path), gameInfo, Page);

            //Si es necesario cancelar.
            if (IsCancelRequested) ThrowCancellationException();

            //Esperando fin de todas las tareas.
            Execute.Run(() => System.Threading.Tasks.Task.WaitAll(TaskList.Select((item) => item.Task).ToArray()));

            //Si es necesario cancelar.
            if (IsCancelRequested) ThrowCancellationException();

            //Obteniendo tareas finalizadas correctamente.
            IEnumerable<TaskManaged> TaskCompletedList = TaskList.Where((task) => !task.IsFaulted && !task.IsCanceled);
            int TasksCompleted = TaskCompletedList.Count();

            //Notificando fin de la operación.
            AddLog(strings.TASK_ADDDIRECTORY_FINDED_BACKUPS.FormatWith(TasksCompleted), LogLevel.Information, Path);

            //Limpiando GameInfo.
            gameInfo.Games.Clear();
            gameInfo.Games.AddRange(TaskCompletedList.Select((task) => task.ResultObject as GameInfoItem));

            //Si es necesario cancelar.
            if (IsCancelRequested) ThrowCancellationException();

            //Guardando GameInfo.
            gameInfo.Save();
        }

        private void AddDirectoryException(TaskManaged task, Exception ex) => ex.AddLog(LogLevel.Error, Path);
        private void AddDirectoryCancel(TaskManaged task) => AddLog(Lang.strings.TASK_ADDDIRECTORY_CANCEL, LogLevel.Warning, Path);

        private string[] GetFiles(string path)
        {
            //Si es necesario cancelar.
            if (IsCancelRequested) ThrowCancellationException();

            //Obteniendo archivos del directorio principal.
            List<string> files = new List<string>();
            Execute.Run(() => files.AddRange(Directory.EnumerateFiles(path)));

            //Si es necesario buscar en subdirectorios.
            if (SubDirectorySearch)
            {
                Execute.Run(() =>
                {
                    foreach (string directory in Directory.EnumerateDirectories(path))
                    {
                        //Si es necesario cancelar.
                        if (IsCancelRequested) ThrowCancellationException();

                        //Lanzando evento.
                        OnSubDirectorySearch?.Invoke(directory);

                        //Agregando archivos a la lista.
                        Execute.Run(() => files.AddRange(GetFiles(directory)));
                    }
                });
            }

            return files.Where((file) => DiskGC.Extensions.Contains(System.IO.Path.GetExtension(file))).ToArray();
        }
    }
}
