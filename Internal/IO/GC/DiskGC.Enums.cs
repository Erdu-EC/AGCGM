using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.IO.GC
{
    public partial class DiskGC
    {
        public enum MagicsWord : uint
        {
            GAMECUBE = 0xc2339f3d
        }

        public enum Country : uint
        {
            USA = 'E',
            EUROPE = 'U',
            EUROPE_Z = 'P',
            JAPAN = 'J'
        }

        public enum Language
        {
            Japones = 0,
            Ingles = 1,
            Aleman = 2,
            Frances = 3,
            Español = 4,
            Italiano = 5,
            Holandes = 6,
            Default = 7
        }
    }
}
