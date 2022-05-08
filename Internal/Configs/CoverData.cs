using AGCGM.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Configs
{
    public class CoverData
    {
        public bool Enabled { get; set; }
        public GameCover.Type Type { get; set; }
        public List<CoverSourceData> Sources { get; set; }

        public CoverData() { }
        public CoverData(GameCover.Type type, bool enable, List<CoverSourceData> sources)
        {
            Enabled = enable;
            Type = type;
            Sources = sources;
        }
    }

    public class CoverSourceData
    {
        public bool Enable { get; set; }
        public string Source { get; set; }

        public CoverSourceData() { }
        public CoverSourceData(string source, bool enabled)
        {
            Enable = enabled;
            Source = source;
        }
    }
}
