using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AGCGM.Internal.Threading
{
    public class TaskManaged
    {
        //Eventos.
        public event Action<TaskManaged> OnFinish;
        public event Action<TaskManaged> OnFinishOK;
        public event Action<TaskManaged, Exception> OnFinishError;
        public event Action<TaskManaged> OnFinishCancel;

        //Lanzadores de eventos.
        protected virtual void RaiseOnFinish() => OnFinish?.Invoke(this);
        protected virtual void RaiseOnFinishOK() => OnFinishOK?.Invoke(this);
        protected virtual void RaiseOnFinishError(Exception ex) => OnFinishError?.Invoke(this, ex);
        protected virtual void RaiseOnFinishCancel() => OnFinishCancel?.Invoke(this);

        //Miembros estaticos.
        public static List<TaskManaged> RunningTasks { get; } = new List<TaskManaged>();

        //Miembros de instancia.
        private readonly CancellationTokenSource cancellationToken;
        private readonly EventWaitHandle eventWait;

        public TaskManaged()
        {
            cancellationToken = new CancellationTokenSource();
            eventWait = new EventWaitHandle(true, EventResetMode.ManualReset);
            Task = new Task(InternalRun, TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent);
        }

        //Propiedades publicas.
        public Task Task { get; private set; }
        public object ResultObject { get; protected set; }

        //Propiedades para comprobacion de estado.
        public bool IsFinished => Task.IsCompleted;
        public bool IsFaulted => Task.IsFaulted;
        public bool IsPause => !eventWait.WaitOne(0);
        public bool IsCanceled { get; private set; } = false;
        public bool IsCancelRequested => cancellationToken.Token.IsCancellationRequested;

        //Metodos publicos para administrar la tarea.
        public void Start()
        {
            lock (RunningTasks) RunningTasks.Add(this);
            Task.Start();
        }

        public void Pause() => eventWait.Reset();

        public void Resume() => eventWait.Set();

        public void Cancel()
        {
            cancellationToken.Cancel();
            if (IsPause) Resume();
        }

        public static void CancelAll()
        {
            lock (RunningTasks) RunningTasks.ForEach((task) => task.Cancel());
        }

        public static void CancelAll<T>() where T: TaskManaged
        {
            lock (RunningTasks) RunningTasks.OfType<T>().ToList().ForEach((task) => task.Cancel());
        }

        //Metodos protegidos para controlar el flujo de la tarea.
        protected bool PauseIfNecessary() => eventWait.WaitOne();

        protected void ThrowCancellationException() => cancellationToken.Token.ThrowIfCancellationRequested();

        //Metodos para la ejecucion de la tarea.
        private void InternalRun()
        {
            try
            {
                Run();
                RaiseOnFinishOK();
            }
            catch (OperationCanceledException)
            {
                IsCanceled = true;
                RaiseOnFinishCancel();
            }
            catch (Exception ex)
            {
                RaiseOnFinishError(ex);
                throw ex;
            }
            finally
            {
                RaiseOnFinish();
                lock (RunningTasks) RunningTasks.Remove(this);
            }
        }

        protected virtual void Run() { }
    }
}
