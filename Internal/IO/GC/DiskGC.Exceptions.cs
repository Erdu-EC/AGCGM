using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.IO.GC
{
    partial class DiskGC
    {
        public class GCException : IOException
        {
            public GCException() { }
            public GCException(string Message) : base(Message) { }
        }

        public class InvalidHeaderException : GCException {
            public InvalidHeaderException(string Message) : base(Message) { }
        }

        public class InvalidDiskException : GCException
        {
            public InvalidDiskException(string Message) : base(Message) { }
        }

        public class GCBackupException : GCException
        {
            public GCBackupException(string Message) : base(Message) { }
        }
    }
}
