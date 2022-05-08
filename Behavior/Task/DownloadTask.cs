using AGCGM.Controls;
using AGCGM.Internal.Serialize;
using AGCGM.Internal.IO.GC;
using AGCGM.Internal.IO.GC.Files;
using AGCGM.Internal.Threading;
using AGCGM.Internal.Tools;
using System;
using System.Drawing;
using System.IO;
using static AGCGM.Behavior.Log;
using static AGCGM.Internal.IO.GC.DiskGC;
using AGCGM.Lang;
using AGCGM.Controls.Page;
using AGCGM.Internal.XMLDB;
using System.Linq;
using System.Net;
using GCGM.Controls;
using System.Collections.Generic;

namespace AGCGM.Behavior.Task
{
    internal class DownloadTask : TaskManaged
    {
        //Miembros de instancia.
        private readonly DownloadItem Item;

        //Propiedades publicas.
        public string BackupName { get; }
        public string BackupCode { get; }

        //Constructor.
        internal DownloadTask(DownloadItem item, string code, string filename)
        {
            item.Tag = this;

            Item = item;
            BackupName = filename;
            BackupCode = code;

            OnFinishError += AddBackupException;
            OnFinishCancel += AddBackupCancel;
        }

        //Miembros para ejecucion de la tarea.

        protected override void Run() => DownloadCover();

        private void DownloadCover()
        {
            //Filtrando los tipos de caratulas que se descargaran.
            var result = Inicio.Settings.Covers.Where((item) =>
            {
                if (item.Enabled)
                {
                    //Habilitando el tipo de caratula en el elemento UI (Label).
                    Item.ReportTypeEnabled(item.Type);

                    return true;
                }
                else
                    return false;
            }).ToArray();

            //Iniciando descarga.
            var finished = result.Select(item => Download(item.Type, item.Sources)).ToArray();

            //Verificando si todas se descargaron.
            if (finished.All(item => item))
            {
                //Exito.
            }
            else
            {
                //Fracaso.
                Item.ReportError();
            }
        }

        private bool Download(GameCover.Type type, IEnumerable<Internal.Configs.CoverSourceData> sourceURLs)
        {
            bool success;

            if (success = GameCover.Exist(type, BackupCode))
                AddLog($"Ya existe una caratula de tipo \"{type.ToString()}\" para el codigo \"{BackupCode}\".", LogLevel.Warning, BackupName);
            else
            {
                foreach (Internal.Configs.CoverSourceData sourceURL in sourceURLs.Where(item => item.Enable))
                {
                    foreach (var item in Inicio.Settings.CoverRegions.OrderBy(item => item.Index))
                    {
                        success = DownloadCover(GameCover.GetUrl(sourceURL.Source, item.Lang, BackupCode), GameCover.GetPath(type));

                        if (!success && item.Lang == Language.Ingles)
                            success = DownloadCover(GameCover.GetUrl(sourceURL.Source, Language.Default, BackupCode), GameCover.GetPath(type));

                        if (success) break;
                    }

                    if (success) break;
                }
            }

            //Informando finalizacion en UI.
            if (success)
                Item.ReportSuccessOf(type);
            else
                Item.ReportErrorOf(type);

            return success;
        }

        private bool DownloadCover(string url, string toPath)
        {
            //Verificando si existe directorio, si no crearlo.
            if (!Directory.Exists(toPath)) Directory.CreateDirectory(toPath);

            //Obteniendo nombre de fichero para escribir.
            toPath = Path.Combine(toPath, $"{BackupCode}.png");

            //Completando URL.
            url = $"https://{url}";

            //Notificando inicio de la operación.
            AddLog($"Obteniendo caratula desde: \"{url}\"", LogLevel.Information, BackupName);

            bool result = false;
            string errorMessage = "desconocida";

            WebClient web = new WebClient();
            web.DownloadProgressChanged += (obj, arg) => Item.ReportProgress(arg.ProgressPercentage);
            web.DownloadFileCompleted += (obj, arg) =>
            {
                if (arg.Error is null)
                    result = true;
                else
                    errorMessage = arg.Error.GetBaseException().Message;

                (arg.UserState as DownloadTask).Resume();
            };
            Pause();
            web.DownloadFileAsync(new Uri(url), toPath, this);
            PauseIfNecessary();

            if (!result)
            {
                File.Delete(toPath); // <-- Eliminando archivo incompleto.
                AddLog($"No fue posible obtener caratula desde: \"{url}\". {errorMessage}", LogLevel.Error, BackupName);
            }

            return result;
        }

        //Miembros privados para log.
        private void AddBackupException(TaskManaged _, Exception ex)
        {
            Item.ReportError();
            ex.AddLog(LogLevel.Error, BackupName);
        }
        private void AddBackupCancel(TaskManaged _) => AddLog(strings.TASK_ADDBACKUP_CANCEL, LogLevel.Warning, BackupName);
    }
}
