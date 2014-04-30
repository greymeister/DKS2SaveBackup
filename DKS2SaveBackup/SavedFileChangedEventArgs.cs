using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKS2SaveBackup
{
    public class SavedFileChangedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
