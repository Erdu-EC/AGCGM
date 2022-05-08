using AGCGM.Internal.IO;
using AGCGM.Internal.Tools;
using GCGM.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static GCGM.Controls.ProgressBarEx;

namespace AGCGM.Internal.Actions
{
    internal static class ProgressBarActions
    {

        public static void SetUsedSpace(this ProgressBarEx bar, Drive data)
        {
            //Cambiando estilo de barra de progreso
            bar.Style = ProgressBarStyle.Continuous;

            //Estableciendo el espacio utilizado en barra de progreso
            bar.Value = Calc.Percentage(data.UsedSpace, data.TotalSpace);

            //Mostrando texto en la barra de progreso
            bar.TextFormat = $"{data.GetFreeSpace()} disponibles de {data.GetTotalSize()}";

            //Estableciendo estado de la barra de progreso
            if (bar.Value >= 90) bar.State = ProgressBarState.Error;
            else if (bar.Value >= 75) bar.State = ProgressBarState.Paused;
            else bar.State = ProgressBarState.Normal;
        }

        public static void Reset(this ProgressBarEx bar)
        {
            bar.Style = ProgressBarStyle.Continuous;
            bar.State = ProgressBarState.Normal;
            bar.TextFormat = "";
            bar.Value = 0;
        }
    }
}
