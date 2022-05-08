using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Tools
{
    internal static class Calc
    {
        public static int Percentage(int num, int max) => (num * 100) / max;
        public static int Percentage(long num, long max) => (int)((num * 100) / max);
    }
}
