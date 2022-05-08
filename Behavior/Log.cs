using AGCGM.Controls.Page;
using AGCGM.Internal.Configs;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Behavior
{
    internal static class Log
    {
        private static TabPage Page;
        private static ListView List;
        private static readonly List<LogEntry> Items = new List<LogEntry>();

        public static void Initialize(TabPage page)
        {
            Page = page;
            List = (page.Controls[0] as LogPage).List;
            
            //Controlando seleccion, para desechar notificacion de cambios.
            ((TabControl)Page.Parent).Selected += (_, arg) =>
            {
                if (arg.TabPage == Page) Page.Text = Lang.strings.CONST_LOG;
            };
        }

        //Enumeraciones
        public enum LogLevel
        {
            Error = 0,
            Warning = 1,
            Information = 2
        }

        public static void AddLog(this Exception ex, LogLevel level, string location = " - ")
        {
            //Creando subitems.
            string[] subitems = {
                " ",
                DateTime.Now.ToShortTimeString(),
                $"{ex.TargetSite.DeclaringType.FullName} [{ex.TargetSite.Name}]",
                ex.GetType().Name,
                ex.Message,
                location,
                ex.StackTrace
            };

            //Añadiendo item a la lista
            Add(subitems, level);
        }

        public static void AddLog(string message, LogLevel level, string location = " - ", int stackOffset = 3)
        {
            //Obteniendo pila e informacion del metodo llamador.
            StackTrace Stack = Execute.Assign(() => new StackTrace(stackOffset), false);
            MethodBase CallerMethod = Stack?.GetFrame(0).GetMethod();

            //Creando subitems
            string[] subitems = {
                " ",
                DateTime.Now.ToShortTimeString(),
                CallerMethod?.DeclaringType.FullName ?? "Unknown",
                CallerMethod?.Name ?? "Unknown",
                message,
                location,
                Stack?.ToString() ?? " - "
            };

            //Añadiendo item a la lista
            Add(subitems, level);
        }

        private static void Add(string[] subitems, LogLevel Level)
        {
            Execute.RunForeground(List, () =>
            {
                //Creando item
                ListViewItem item = new ListViewItem(subitems)
                {
                    Group = List.Groups[Enum.GetName(typeof(LogLevel), Level)],
                    StateImageIndex = (int)Level,
                    ForeColor = Level == LogLevel.Error ? Color.Red : Level == LogLevel.Warning ? Color.DarkOrange : Color.Black
                };

                //Añadiendo item a las listas
                Items.Add(new LogEntry(Level, List.Items.Add(item)));

                //Notificando modificacion
                TabPage TabSelect = ((TabControl)Page.Parent)?.SelectedTab;
                if (TabSelect != null && !TabSelect.Equals(Page) && !Page.Text.Equals(Lang.strings.CONST_LOG_CHANGED))
                    Page.Text = Lang.strings.CONST_LOG_CHANGED;
            });
        }

        public static void Refresh(bool Error = true, bool Warning = true, bool Info = true)
        {
            List.SuspendLayout();
            List.Items.Clear();

            foreach (LogEntry item in Items)
            {
                if (!Error && item.Level == LogLevel.Error) continue;
                if (!Warning && item.Level == LogLevel.Warning) continue;
                if (!Info && item.Level == LogLevel.Information) continue;

                List.Items.Add(item.Item);
            }

            List.ResumeLayout();
        }

        public static void Clear()
        {
            List.Items.Clear();
            Items.Clear();
        }

        //Clases Varias
        class LogEntry
        {
            public LogLevel Level { get; }
            public ListViewItem Item { get; }

            public LogEntry(LogLevel level, ListViewItem item)
            {
                Level = level;
                Item = item;
            }
        }
    }
}