using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DKS2SaveBackup
{
    public class SavedFileChangedEventArgs : EventArgs
    {
        public DateTime TimeReached { get; set; }
        public FileSystemEventArgs fileEvent { get; set; }
    }
}
