﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKS2SaveBackup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Log("{0} Starting Save File Watcher", DateTime.Now);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
