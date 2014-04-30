using System;
using Microsoft.Win32;

namespace DKS2SaveBackup
{
    class SaveFileBackupProcess
    {
        private int numberOfSaves;
        const int defaultSaves = 20;
        // The name of the key must include a valid root. 
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "DKS2SaveBackup";
        const string keyName = userRoot + "\\" + subkey;

        public SaveFileBackupProcess() 
        {
            InitializeBackupConfiguration();
        }

        private void InitializeBackupConfiguration()
        {
            if (Registry.GetValue(keyName, "NUMBER_OF_SAVES", defaultSaves) != null)
            {
                numberOfSaves = (int)Registry.GetValue(keyName, "NUMBER_OF_SAVES", defaultSaves);
            }
            else
            {
                numberOfSaves = defaultSaves;
            }
            
            Registry.SetValue(keyName, "NUMBER_OF_SAVES", numberOfSaves); 
        }

        public void SaveFileChanged(SavedFileChangedEventArgs e)
        {

        }

        public int getNumberOfSaves()
        {
            return this.numberOfSaves;
        }

        public void setNumberOfSaves(int numberOfSaves)
        {
            this.numberOfSaves = numberOfSaves;
            Registry.SetValue(keyName, "NUMBER_OF_SAVES", numberOfSaves); 
        }

    }
}
