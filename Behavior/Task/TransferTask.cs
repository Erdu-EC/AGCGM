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
using GCGM.Controls;

namespace AGCGM.Behavior.Task
{
    public class TransferTask : TaskManaged
    {
        //Propiedades publicas.
        public TransferItem Item { get; private set; }
        private readonly bool Trim;

        //Constructor.
        internal TransferTask(TransferItem item, bool trim)
        {
            Trim = trim;

            //Controlando eventos del item.
            item.Tag = this;
            Item = item;

            OnFinishError += TransferException;
            OnFinishCancel += TransferCancel;
            OnFinishOK += TransferFinish;
        }

        //Miembros para ejecucion de la tarea.
        protected override void Run() => Transfer();

        private void Transfer()
        {
            //Verificando si se debe detener la tarea.
            if (IsCancelRequested) ThrowCancellationException();

            //Abriendo disco fuente.
            DiskGC disc = new DiskGC(Item.SourcePath);

            //Transfiriendo a destino.
            if (Trim)
                disc.Trim(Item.DestinationPath, (perc) => Item.ReportProgress(perc), () =>
                {
                    if (!IsCancelRequested)
                        PauseIfNecessary();

                    return IsCancelRequested;
                });
            else
            {
                disc.Copy(Item.DestinationPath, (perc) => Item.ReportProgress(perc), () =>
                {
                    if (!IsCancelRequested)
                        PauseIfNecessary();

                    return IsCancelRequested;
                });
            };

            //Verificando si se debe detener la tarea.
            if (IsCancelRequested) ThrowCancellationException();

            //Notificando exito.
            Item.ReportSuccess();
        }

        public new void Pause()
        {
            base.Pause();
            Item.ReportPause();
        }

        public new void Resume()
        {
            base.Resume();
            if (!IsCancelRequested)
                Item.ReportResume();
        }

        //Miembros privados para log.
        private void TransferFinish(TaskManaged _)
        {
            Execute.RunForeground(Item, () => (Item.Parent.Parent.Parent as TransferContainer).CountTransfers());
            AddLog("Transferencia completada.", LogLevel.Information, $"{Item.SourcePath} => {Item.DestinationPath}");
        }
        private void TransferException(TaskManaged _, Exception ex)
        {
            Execute.OnErrorLog(() => File.Delete(Item.DestinationPath), LogLevel.Warning, $"{Item.SourcePath} => {Item.DestinationPath}");
            Item.ReportError(ex.Message);
            ex.AddLog(LogLevel.Error, $"{Item.SourcePath} => {Item.DestinationPath}");
        }
        private void TransferCancel(TaskManaged _)
        {
            Execute.OnErrorLog(() => File.Delete(Item.DestinationPath), LogLevel.Warning, $"{Item.SourcePath} => {Item.DestinationPath}");
            Item.ReportCancel();
            AddLog("Transferencia cancelada exitosamente.", LogLevel.Warning, $"{Item.SourcePath} => {Item.DestinationPath}");
        }
    }
}
