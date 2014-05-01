using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKS2SaveBackup
{
    class Logger
    {
        const string logName = "DKS2SaveBackup.log";
        public static void Log(String lines)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter( GetLogName(), true);
            file.WriteLine(lines);
            file.Close();
        }

        public static void Log(string format, object arg0)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(GetLogName(), true);
            file.WriteLine(format, arg0);
            file.Close();
        }

        public static void Log(string format, object arg0, object arg1)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(GetLogName(), true);
            file.WriteLine(format, arg0, arg1);
            file.Close();
        }

        public static void Log(string format, object arg0, object arg1, object arg2)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(GetLogName(), true);
            file.WriteLine(format, arg0, arg1, arg2);
            file.Close();
        }

        private static string GetLogName()
        {
            string path = System.IO.Path.GetTempPath() + logName;
            return path;
        }        
    }
}
