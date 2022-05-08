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

namespace AGCGM.Controls.Page
{
    public partial class LogPage : UserControl
    {
        public LogPage()
        {
            InitializeComponent();
            List.ListViewItemSorter = new ListViewItemSorter(List);
            (List.StateImageList = new ImageList()).Images.AddRange(
                new Image[]
                {
                    ResX.Icons.Error_20x20,
                    ResX.Icons.Warning_20x20,
                    ResX.Icons.Information_20x20
                });
        }

        //Propiedades publicas.
        public ListView List => LogList;

        //Controladores de evento.
        private void LogFilter_Click(object sender, EventArgs e) => Log.Refresh(BTLogError.Checked, BTLogWarning.Checked, BTLogInfo.Checked);

        private void LogClear_Click(object sender, EventArgs e) => Log.Clear();

        private void LogList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemSorter ItemSorter = List.ListViewItemSorter as ListViewItemSorter;

            if (e.Column == ColumnTime.Index)
                ItemSorter.Sort(e.Column, ListViewItemSorter.TypeColumn.DateTime);
            else if (e.Column == ColumnIcon.Index)
                ItemSorter.Sort(e.Column, ListViewItemSorter.TypeColumn.StateImageIndex);
            else
                ItemSorter.Sort(e.Column);
        }
    }
}
