using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.XMLDB
{
    internal class TDBCompany
    {
        public string Code { get; }
        public string Name { get; }

        public TDBCompany(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
