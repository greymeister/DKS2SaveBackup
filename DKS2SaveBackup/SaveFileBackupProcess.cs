using System;
using Microsoft.Win32;
using System.IO;
using System.Threading;

namespace DKS2SaveBackup
{
    class SaveFileBackupProcess
    {
        private const int defaultSaves = 20;
        // The name of the key must include a valid root. 
        private const string userRoot = "HKEY_CURRENT_USER";
        private const string subkey = "DKS2SaveBackup";
        private const string NUMBER_OF_SAVES = "NUMBER_OF_SAVES";
        private const string LAST_SAVE = "LAST_SAVE";
        private const string keyName = userRoot + "\\" + subkey;
        private const string DARK_SOULS_2_SAVE_FILE = "DARKSII0000.sl2";
        private int numberOfSaves;
        private DateTime lastFired;
        private static readonly Object obj = new Object();

        public int NumberOfSaves
        {
            get { return numberOfSaves; }
            set
            {
                Logger.Log("{0} Updating number of saves from {1} to {2}", DateTime.Now, numberOfSaves, value);
                numberOfSaves = value;
                Registry.SetValue(keyName, NUMBER_OF_SAVES, numberOfSaves);
            }
        }

        public SaveFileBackupProcess() 
        {
            InitializeBackupConfiguration();
            lastFired = DateTime.MinValue;
        }

        private void InitializeBackupConfiguration()
        {
            if (Registry.GetValue(keyName, NUMBER_OF_SAVES, defaultSaves) != null)
            {
                numberOfSaves = (int)Registry.GetValue(keyName, NUMBER_OF_SAVES, defaultSaves);
            }
            else
            {
                numberOfSaves = defaultSaves;
            }

            Registry.SetValue(keyName, NUMBER_OF_SAVES, NumberOfSaves); 
        }

        public void SaveFileChanged(SavedFileChangedEventArgs e)
        {
            lock (obj)
            {                
                if (TimeElapsedSinceLastEvent(e.TimeReached))
                {
                    Logger.Log("{0} Backing up save updated at {1}", DateTime.Now, e.TimeReached);
                    FileSystemEventArgs fileEvent = e.fileEvent;
                    string saveFilePath = fileEvent.FullPath;
                    CreateBackupCopy(saveFilePath);
                    Thread.Sleep(5000);
                    lastFired = DateTime.Now;
                }
            }
        }

        private bool TimeElapsedSinceLastEvent(DateTime eventTime)
        {
            return (eventTime - lastFired).TotalSeconds > 90;
        }

        protected void CreateBackupCopy(string saveFilePath)
        {
            var lastSave = CalculateLastSave();
            CopyFile(saveFilePath, lastSave);
            UpdateLastSave(lastSave);
        }       

        private int CalculateLastSave()
        {
            if (Registry.GetValue(keyName, LAST_SAVE, 0) != null)
            {
                return (int)Registry.GetValue(keyName, LAST_SAVE, 0);
            }
            else
            {
                return 0;
            }
        }

        private void CopyFile(string saveFilePath, int lastSave)
        {
            var destinationPath = saveFilePath + ".BAK." + lastSave;
            Logger.Log("{0} Writing to file at {1}", DateTime.Now, destinationPath);
            File.Copy(saveFilePath, destinationPath, true);
        }

        private void UpdateLastSave(int lastSave)
        {
            if (lastSave > numberOfSaves)
            {
                lastSave = 0;
            }
            else
            {
                lastSave += 1;
            }

            Registry.SetValue(keyName, LAST_SAVE, lastSave);
        }

    }
}
