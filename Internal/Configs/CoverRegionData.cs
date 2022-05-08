using AGCGM.Behavior;
using AGCGM.Internal.IO.GC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Configs
{
    public class CoverRegionData
    {
        public bool Enabled { get; set; }

        public int Index { get; set; }

        public DiskGC.Language Lang { get; set; }

        public CoverRegionData() { }
        public CoverRegionData(DiskGC.Language lang, int index, bool enabled)
        {
            Index = index;
            Enabled = enabled;
            Lang = lang;
        }
    }
}
