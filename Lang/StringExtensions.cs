using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Lang
{
    internal static class StringExtensions
    {
        public static string FormatWith(this string format, params object[] args) => string.Format(format, args);
    }
}
