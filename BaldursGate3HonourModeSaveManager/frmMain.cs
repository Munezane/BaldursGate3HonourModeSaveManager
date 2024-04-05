using System;
using System.Linq;
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
            MessageBox.Show(message, "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            Console.WriteLine(message);
        }
        private void AlertSuccess(string message)
        {
            MessageBox.Show(message, "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            Console.WriteLine(message);
        }


        private void dgvSaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //clicked on header, do nothing
                return;
            }
            DataGridView grid = ((DataGridView)sender);
            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                var dataItem = (BackupSaveItem)grid.Rows[e.RowIndex].DataBoundItem;
                var confirmResult = MessageBox.Show($"Are you sure you want to restore the save at {dataItem.Path}? You should quit to the main menu first.",
                                     "Confirm restore",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // If 'Yes'...
                    BaldursGate3SaveFileManagerResult result = BaldursGate3SaveFileManager.RestoreBackup(configManager.HonourModeSaveLocation, dataItem.Path);

                    if (result.Success.GetValueOrDefault())
                    {
                        //TO DO:
                        //btnUndoSaveRestore.Enabled = true; //NOT IMPLEMENTED YET!

                        AlertSuccess("Save restored. You may continue your game");
                        RefreshGridSaves();
                    }
                    else
                    {
                        AlertError($"Restoration failed: {result.ErrorMessage}");
                    }
                    
                }
                else
                {
                    // If 'No', do nothing
                }
            }
        }

        private void dgvSaves_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            foreach(DataGridViewRow row in grid.Rows)
            {
                BackupSaveItem dataItem = (BackupSaveItem)row.DataBoundItem;
                if (dataItem.SaveThumbnail != null)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.GetType() == typeof(DataGridViewImageCell))
                        {
                            //set the image!
                            DataGridViewImageCell imageCell = (DataGridViewImageCell)cell;
                            imageCell.Value = dataItem.SaveThumbnail;
                            break;
                        }
                    }
                }
                
            }
        }
    }
}
