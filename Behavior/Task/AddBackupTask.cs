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

namespace AGCGM.Behavior.Task
{
    internal class AddBackupTask : TaskManaged
    {
        //Miembros de instancia.
        private readonly GameInfo GameList;
        private readonly GamePage Page;
        private readonly TDBDatabase DB;

        //Propiedades publicas.
        public string BackupName { get; private set; }

        //Constructor.
        internal AddBackupTask(string filename, GameInfo info, GamePage page, TDBDatabase db)
        {
            BackupName = filename;
            GameList = info;
            Page = page;
            DB = db;

            OnFinishError += AddBackupException;
            OnFinishCancel += AddBackupCancel;
        }

        //Miembros para ejecucion de la tarea.
        protected override void Run() => AddBackup();

        private void AddBackup()
        {
            GCHeader GCHeader;
            Image cacheBanner;

            DiskGC Disk = null;
            GameInfoItem gameItem = null;
            BNR bnr = null;

            //Verificando si se debe detener la tarea.
            if (IsCancelRequested) ThrowCancellationException();

            //Abriendo imagen del backup.
            using (FileStream stream = File.OpenRead(BackupName))
            {
                //Generando cabecera de la imagen.
                GCHeader = new GCHeader(new BinaryReader(stream));

                //Obteniendo informacion del juego, si existe.
                if (GameList != null)
                    lock (GameList) gameItem = GameList.Find(GCHeader.GetGameID());

                //Obteniendo banner si existe en la cache.
                cacheBanner = Cache.GetBanner(GCHeader.GetGameID());

                //Si no existe informacion, esta no es valida o el banner no existe en cache.
                if (gameItem is null || !gameItem.IsValid() || cacheBanner is null)
                {
                    //Abriendo Backup.
                    Disk = new DiskGC(stream, GCHeader);

                    //Obteniendo BNR.
                    if ((bnr = Disk.GetBNR(cacheBanner)) is null)
                        AddLog(strings.TASK_ADDBACKUP_MISSING_BANNER, LogLevel.Warning, BackupName);
                }
            }

            //Verificando si se debe detener la tarea.
            if (IsCancelRequested) ThrowCancellationException();

            if (bnr != null)
            {
                //Guardando BNR en cache.
                Execute.OnErrorLog(() => Cache.SaveBanner(GCHeader.GetGameID(), bnr.Image), LogLevel.Warning, BackupName);

                //Obteniendo imagen.
                cacheBanner = bnr.Image;
            }

            //Agregando banners a la lista.
            if (Page.Banners != null && cacheBanner != null)
            {
                lock (Page.Banners) Page.AddBanner(GCHeader.GetGameID(), cacheBanner);
            }

            //Generando GameInfo.
            if (Disk != null)
            {
                //Obteniendo datos de BD.
                TDBGame game = DB?.GetGameByCode(GCHeader.FullCode);

                gameItem = new GameInfoItem(
                    ID: GCHeader.DiskID,
                    Code: GCHeader.FullCode,
                    Title: game?.Titles?.First().Value ?? bnr?.GetName(Language.Español) ?? GCHeader.GameName,
                    Maker: game?.Developer ?? game?.Publisher ?? bnr?.GetDeveloper(Language.Español) ?? GCHeader.MakerName,
                    Country: GCHeader.CountryName,
                    Length: Disk.GetLength()
                );
            }

            //Estableciendo resultado.
            ResultObject = gameItem;

            //Ejecutando Callback.
            Page.AddGame(BackupName, gameItem);

            //Notificando finalizacion correcta.
            AddLog(strings.TASK_ADDBACKUP_ADDED_SUCESS, LogLevel.Information, BackupName);
        }

        //Miembros privados para log.
        private void AddBackupException(TaskManaged _, Exception ex) => ex.AddLog(LogLevel.Error, BackupName);
        private void AddBackupCancel(TaskManaged _) => AddLog(strings.TASK_ADDBACKUP_CANCEL, LogLevel.Warning, BackupName);
    }
}
