using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Internal.Tools
{
    class ListViewItemSorter : IComparer
    {
        //Propiedades publicas.
        public ListView List { get; }
        public int ColumnIndex { set; get; } = 0;
        public TypeColumn ColumnType { get; set; } = TypeColumn.Text;
        public SortOrder Order { set; get; } = SortOrder.None;

        public enum TypeColumn
        {
            Text,
            DateTime,
            DataSize,
            StateImageIndex
        }

        //Constructor.
        public ListViewItemSorter(ListView list) => List = list;

        public int Compare(object x, object y)
        {
            //Si no hay que ordenar.
            if (Order == SortOrder.None) return 0;

            //Obteniendo valores.
            int compareResult;
            string valueX = (x as ListViewItem).SubItems[ColumnIndex].Text;
            string valueY = (y as ListViewItem).SubItems[ColumnIndex].Text;

            //Comparando objetos.
            switch (ColumnType)
            {
                case TypeColumn.DateTime:
                    compareResult = DateTime.Compare(DateTime.Parse(valueX), DateTime.Parse(valueY));
                    break;
                case TypeColumn.DataSize:
                    compareResult = DataSize.Compare(DataSize.Parse(valueX), DataSize.Parse(valueY));
                    break;
                case TypeColumn.StateImageIndex:
                    compareResult = Comparer<int>.Default.Compare((x as ListViewItem).StateImageIndex, (y as ListViewItem).StateImageIndex);
                    break;
                default:
                    compareResult = Comparer.Default.Compare(valueX, valueY);
                    break;
            }

            if (Order == SortOrder.Ascending)
                return compareResult;
            else if (Order == SortOrder.Descending)
                return (-compareResult);
            else
                return 0;
        }

        public void Sort(int columnIndex, TypeColumn columnType = TypeColumn.Text)
        {
            List.SuspendLayout();
            Order = List.Sorting = List.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            ColumnIndex = columnIndex;
            ColumnType = columnType;
            List.Sort();
            List.ResumeLayout(true);
        }
    }
}
