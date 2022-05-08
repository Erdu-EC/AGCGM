using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Configs
{
    public class DirectoryData
    {
        public string Path { get; set; } = null;
        public bool NewTab { get; set; } = false;
        public bool Active { get; set; } = true;

        public DirectoryData() { }
        public DirectoryData(string Path, bool NewTab = false, bool Active = true)
        {
            this.Path = Path;
            this.NewTab = NewTab;
            this.Active = Active;
        }
    }
}
