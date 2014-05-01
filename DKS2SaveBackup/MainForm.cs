using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DKS2SaveBackup
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private SaveFileWatcher saveFileWatcher;
        private SaveFileBackupProcess saveFileBackupProcess;

        public MainForm()
        {
            InitializeComponent();
            InitializeTrayIcon();
            saveFileWatcher = new SaveFileWatcher();
            saveFileWatcher.SavedFileChanged += OnSaveFileChanged;

            saveFileBackupProcess = new SaveFileBackupProcess();
        }

        private void InitializeTrayIcon()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Settings", OnClick);
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "DKS2SaveBackup";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            trayIcon.Icon = new Icon(((System.Drawing.Icon)(resources.GetObject("$this.Icon"))), 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.DoubleClick += new System.EventHandler(this.OnClick);
            trayIcon.Visible = true;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true; 
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false; // Remove from taskbar.
            e.Cancel = true; // this cancels the close event.
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            saveFileWatcher.stopWatcher();
            Logger.Log("{0} Exiting program", DateTime.Now);
            Dispose(true);
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnSaveFileChanged(object sender, SavedFileChangedEventArgs e)
        {            
            saveFileBackupProcess.SaveFileChanged(e);
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            int previousNumberOfSaves = saveFileBackupProcess.NumberOfSaves;
            int newNumberOfSaves;
            try
            {
                newNumberOfSaves = int.Parse(this.textBox1.Text);
            }
            catch (FormatException)
            {
                newNumberOfSaves = previousNumberOfSaves;
                this.textBox1.Text = previousNumberOfSaves.ToString();
            }

            saveFileBackupProcess.NumberOfSaves = newNumberOfSaves;
        }
    }
}
