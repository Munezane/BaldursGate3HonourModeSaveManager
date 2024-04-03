namespace BaldursGate3HonourModeSaveManager
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private ConfigManager configManager = new ConfigManager();

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool blnConfigSet = (configManager.HonourModeSaveLocation != null && configManager.BackupSaveLocation != null);
            dgvSaves.Enabled = blnConfigSet;
            btnRefreshBackupGrid.Enabled = blnConfigSet;
            btnBackupCurrentSave.Enabled = blnConfigSet; btnBackupCurrentSave.Enabled = false;

            if (configManager.HonourModeSaveLocation != null)
            {
                txtPathToHonourModeSave.Text = configManager.HonourModeSaveLocation;
                btnBackupCurrentSave.Enabled = true;
            }
            if (configManager.BackupSaveLocation != null)
            {
                txtBackupSaveLocation.Text = configManager.BackupSaveLocation;
            }

            if (dgvSaves.Enabled)
            {
                RefreshGridSaves();
            }
        }

        private void RefreshGridSaves()
        {
            try
            {
                dgvSaves.DataSource = BaldursGate3SaveFileManager.GetBackupSaveItems(configManager.BackupSaveLocation);
                dgvSaves.Refresh();

            }
            catch (Exception ex)
            {
                AlertError($"Failed to refresh grid: {ex.Message}");
            }

        }

        private void btnPathToHonourSave_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdMain.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathToHonourModeSave.Text = fbdMain.SelectedPath;
                configManager.HonourModeSaveLocation = txtPathToHonourModeSave.Text;
                try
                {
                    configManager.SaveConfig();
                }
                catch (Exception ex)
                {
                    AlertError($"Failed to save to config file: {ex.Message}");
                }
            }
        }

        private void btnBackupSaveLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdMain.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBackupSaveLocation.Text = fbdMain.SelectedPath;
                configManager.BackupSaveLocation = txtBackupSaveLocation.Text;
                try
                {
                    configManager.SaveConfig();
                }
                catch (Exception ex)
                {
                    AlertError($"Failed to save to config file: {ex.Message}");
                }
            }
        }

        private void btnRefreshBackupGrid_Click(object sender, EventArgs e)
        {
            RefreshGridSaves();
        }

        private void btnBackupCurrentSave_Click(object sender, EventArgs e)
        {
            BaldursGate3SaveFileManagerResult result = BaldursGate3SaveFileManager.BackupCurrentSave(configManager.HonourModeSaveLocation, configManager.BackupSaveLocation, configManager.MaxBackupsToStore);
            if (!result.Success.GetValueOrDefault())
            {
                //warn user something went wrong!
                AlertError($"Backup failed: {result.ErrorMessage}");
            }
            else
            {
                AlertSuccess("Backup successful");
                RefreshGridSaves();
            }
        }

        private void AlertError(string message)
        {
            //TO DO! GUI!
            //
            Console.WriteLine(message);
        }
        private void AlertSuccess(string message)
        {
            //TO DO! GUI!
            //
            Console.WriteLine(message);
        }

        private void dgvSaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if sender is button? Or if e.columnIndex is button
            //if (sender)
            //{
            ////restore backup
            ///enable undo button
            ///refresh grid
            //}
        }
    }
}
