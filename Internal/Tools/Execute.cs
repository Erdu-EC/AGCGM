using AGCGM.Behavior;
using AGCGM.Internal.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static AGCGM.Behavior.Log;

namespace AGCGM.Internal.Tools
{
    internal static class Execute
    {
        public static T Assign<T>(Func<T> action, bool log = false)
        {
            try { return action.Invoke(); }
            catch { return default; }
        }

        public static T AssignLog<T>(Func<T> action, string message, LogLevel level, string location)
        {
            try { return action.Invoke(); }
            catch (Exception ex)
            {
                if (message is null)
                    ex.AddLog(level, location);
                else
                    AddLog(message, level, location, 4);
                return default;
            }
        }

        public static bool Run(Action action, Action <Exception> OnError = null)
        {
            try
            {
                action();
                return true;
            }catch(Exception ex)
            {
                //ex.AddLog(LogLevel.Error);
                OnError?.Invoke(ex);
                return false;
            }
        }

        public static bool RunForeground(Control control, Action action, Action<Exception> OnError = null)
        {
            if (!control.IsDisposed)
            {
                if (control.InvokeRequired)
                    return (bool)control.Invoke(new Func<Action, Action<Exception>, bool>(Run), action, OnError);
                else
                    return Run(action, OnError);
            }
            else
                return false;
        }

        public static DialogResult OnErrorShow(Action action, string message, string title)
        {
            return OnErrorShow(action, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult OnErrorShow(Action action, string message, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            try
            {
                action();
                return DialogResult.None;
            }
            catch (Exception ex)
            {
                ex.AddLog(LogLevel.Error); // <--
                return MessageBox.Show(message ?? ex.Message, title, button, icon);
            }
        }

        public static bool OnErrorLog(Action action, LogLevel level = LogLevel.Error, string ubicacion = "-")
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                ex.AddLog(level, ubicacion); // <--
                return false;
            }
        }
    }
}
