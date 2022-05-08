using AGCGM.Controls;
using AGCGM.Controls.Page;
using AGCGM.Internal.Configs;
using AGCGM.Internal.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Behavior
{
    public class GameTabs
    {
        //Miembros privados.
        private readonly TabControl Tabs;

        //Propiedades publicas.
        public TabPage MainPage { get; }

        public TabPage[] TabPages => (from TabPage page in Tabs.TabPages where page.Controls[0] is GamePage && page != MainPage select page).ToArray();

        //Constructor.
        public GameTabs(TabControl tabs, TabPage mainPage)
        {
            Tabs = tabs;
            MainPage = mainPage;
        }

        //Enumeraciones.
        enum TypeTab
        {
            Drive,
            Directory
        }

        //Metodos publicos.
        public TabPage CreateTab(string path)
        {
            TabPage page = null;

            Execute.RunForeground(Tabs, () =>
            {
                //Si ya existe pestaña, devolverla.
                if (ContainsTab(path))
                {
                    page = GetTab(path);
                    return;
                }

                //Creando pestaña.
                page = new TabPage()
                {
                    Name = path,
                    Text = Path.GetFileName(path),
                    ToolTipText = path,
                    Tag = TypeTab.Directory,
                    Padding = new Padding(3),
                    UseVisualStyleBackColor = true
                };

                if (string.IsNullOrWhiteSpace(page.Text) && Path.GetPathRoot(path) == path)
                    page.Text = Execute.Assign(() => new DriveInfo(path).VolumeLabel);

                //Agregando lista.
                page.Controls.Add(new GamePage(path, external: true) { Dock = DockStyle.Fill });

                //Agregando a tabs.
                Tabs.TabPages.Add(page);

                //Agregando icono de pestaña.
                page.ImageKey = "Folder_32";
            });

            return page;
        }
        public TabPage CreateTab(DriveData drive, DriveType type)
        {
            TabPage page = null;

            Execute.RunForeground(Tabs, () =>
            {
                //Si ya existe pestaña, devolverla.
                if (ContainsTab(drive.GetID()))
                {
                    page = GetTab(drive.GetID());
                    return;
                }

                //Creando pestaña.
                page = new TabPage()
                {
                    Name = drive.GetID(),
                    Text = drive.GetFormatedLabel(),
                    ToolTipText = drive.GetGCRoot(),
                    Tag = TypeTab.Drive,
                    Padding = new Padding(3),
                    UseVisualStyleBackColor = true,
                };

                //Agregando lista.
                page.Controls.Add(new GamePage(drive.GetGCRoot(), external: true) { Dock = DockStyle.Fill, DriveData = drive });

                //Agregando a tabs.
                Tabs.TabPages.Add(page);

                //Agregando icono de pestaña.
                page.ImageKey = type.ToString() + "_32";
            });

            return page;
        }

        public TabPage GetTab(string id) => Tabs.TabPages.ContainsKey(id) ? Tabs.TabPages[id] : null;

        public bool ContainsTab(string id) => Tabs.TabPages.ContainsKey(id);

        /*public void RemoveTab(string name)
        {
            if (Tabs.InvokeRequired)
            {
                Tabs.Invoke(new Action<string>(RemoveTab), name);
            }
            Tabs.TabPages.RemoveByKey(name);
        }*/
    }
}
