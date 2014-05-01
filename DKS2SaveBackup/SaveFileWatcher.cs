using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace DKS2SaveBackup
{
    class SaveFileWatcher
    {
        public event EventHandler<SavedFileChangedEventArgs> SavedFileChanged;
        private FileSystemWatcher watcher;
        private const string DARK_SOULS_2_SAVEDIR = @"\AppData\Roaming\DarkSoulsII\";
        private const string DARK_SOULS_2_SAVE_FILE = @"\DARKSII0000.sl2";
        private string filePath;

        public SaveFileWatcher()
        {
            InitializeSaveFilePath();
            InitializeWatcher();
        }

        public void stopWatcher()
        {
            watcher.EnableRaisingEvents = false;
        }


        private void InitializeSaveFilePath()
        {
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string darkSoulsRootDir = userProfilePath + DARK_SOULS_2_SAVEDIR;
            filePath = Directory.GetDirectories(darkSoulsRootDir).First();
            Logger.Log("{0} Dark Souls II Save Directory: {1}", DateTime.Now, filePath);
        }

        // Create a new FileSystemWatcher and set its properties.
        private void InitializeWatcher()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = filePath;
            // Watch for changes in LastWrite times 
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            // Only watch main save file
            watcher.Filter = "*.sl2";            
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            //Logger.Log("{0} File Change Detected: {1} {2}", DateTime.Now, e.FullPath, e.ChangeType);
            Thread.Sleep(5000);
            DispatchEvent(e);
        }

        protected virtual void DispatchEvent(FileSystemEventArgs e)
        {
            EventHandler<SavedFileChangedEventArgs> handler = SavedFileChanged;
            if (handler != null)
            {
                var args = new SavedFileChangedEventArgs();
                args.fileEvent = e;
                args.TimeReached = DateTime.Now;
                handler(this, args);
            }
        }


    }
}
