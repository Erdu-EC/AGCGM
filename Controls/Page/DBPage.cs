using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGCGM.Behavior;
using System.Collections;
using AGCGM.Internal.Tools;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using AGCGM.Internal.XMLDB;

namespace AGCGM.Controls.Page
{
    public partial class DBPage : UserControl
    {
        internal TDBDatabase DB { get; private set; }

        public DBPage()
        {
            InitializeComponent();
            List.ListViewItemSorter = new ListViewItemSorter(List);
        }

        internal void Initialize(TDBDatabase database)
        {
            DB = database;
            BTFilter.PerformClick();
        }

        private void UpdateList(IEnumerable<TDBGame> games)
        {
            SuspendLayout();
            List.SuspendLayout();
            List.Items.Clear();
            List.Items.AddRange(games.Select(game => new ListViewItem(new string[]
            {
                game.Code,
                game.Titles.Length > 0 ? game.Titles.First().Value : "",
                game.Players.ToString(),
                game.GetType(),
                game.GetRegion(),
                game.GetLanguages(),
                game.Developer,
                game.Publisher,
                game.Date.ToShortDateString()
            })).ToArray());
            List.ResumeLayout(false);
            ResumeLayout(true);
        }

        private void List_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemSorter ItemSorter = List.ListViewItemSorter as ListViewItemSorter;

            if (e.Column == ColumnDate.Index)
                ItemSorter.Sort(e.Column, ListViewItemSorter.TypeColumn.DateTime);
            else
                ItemSorter.Sort(e.Column);
        }

        private void BTFilter_Click(object sender, EventArgs e)
        {
            BTFilter.Enabled = false;

            var games = DB.GetGames().AsParallel();
            string text = TBSearch.Text.Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(text))
                games = games.Where(game => game.Titles.Where(title => title.Value?.ToLower().Contains(text) ?? false).Count() > 0);

            if (ButtonFilter_Wii.Checked || ButtonFilter_GameCube.Checked || ButtonFilter_Other.Checked)
                games = games.Where(game => CheckCondicion(game));

            UpdateList(games);

            BTFilter.Enabled = true;

            bool CheckCondicion(TDBGame game)
            {
                bool wii = ButtonFilter_Wii.Checked && (game.Type == TDBEnums.GameType.WiiGame || game.Type == TDBEnums.GameType.WiiWare);
                bool gamecube = ButtonFilter_GameCube.Checked && game.Type == TDBEnums.GameType.GameCube;
                bool other = ButtonFilter_Other.Checked && (game.Type != TDBEnums.GameType.WiiGame && game.Type != TDBEnums.GameType.WiiWare && game.Type != TDBEnums.GameType.GameCube);

                return wii || gamecube || other;
            }
        }
    }
}
