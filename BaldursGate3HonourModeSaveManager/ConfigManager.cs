using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace BaldursGate3HonourModeSaveManager
{
    internal class ConfigManager
    {
        public ConfigManager() {
            LoadConfig();
        }
        public int MaxBackupsToStore { get; set; } = 3;//3 by default
        public string HonourModeSaveLocation { get; set; }
        public string BackupSaveLocation { get; set; }

        public void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;

            KeyValueConfigurationElement kvpMaxBackups = app.Settings["MaxBackupsToStore"];
            KeyValueConfigurationElement kvpHonourModeSaveLocation = app.Settings["HonourModeSaveLocation"];
            KeyValueConfigurationElement kvpBackupSaveLocation = app.Settings["BackupSaveLocation"];

            kvpMaxBackups.Value = MaxBackupsToStore.ToString();
            kvpHonourModeSaveLocation.Value = HonourModeSaveLocation;
            kvpBackupSaveLocation.Value = BackupSaveLocation;
            config.Save(ConfigurationSaveMode.Modified);
        }

        public void LoadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;

            KeyValueConfigurationElement kvpMaxBackups = app.Settings["MaxBackupsToStore"];
            KeyValueConfigurationElement kvpHonourModeSaveLocation = app.Settings["HonourModeSaveLocation"];
            KeyValueConfigurationElement kvpBackupSaveLocation = app.Settings["BackupSaveLocation"];

            bool blnNeedSaveConfig = false;
            if (kvpMaxBackups == null)
            {
                app.Settings.Add("MaxBackupsToStore", MaxBackupsToStore.ToString());
                blnNeedSaveConfig = true;
            }
            if (kvpHonourModeSaveLocation == null)
            {
                app.Settings.Add("HonourModeSaveLocation", HonourModeSaveLocation);
                blnNeedSaveConfig = true;
            }
            if (kvpBackupSaveLocation == null)
            {
                app.Settings.Add("BackupSaveLocation", BackupSaveLocation);
                blnNeedSaveConfig = true;
            }
            if (blnNeedSaveConfig)
            {
                config.Save(ConfigurationSaveMode.Modified);
            }
            string maxBackupsToStore = app.Settings["MaxBackupsToStore"]?.Value;
            string honourModeSaveLocation = app.Settings["HonourModeSaveLocation"]?.Value;
            string backupSaveLocation = app.Settings["BackupSaveLocation"]?.Value;

            if (!string.IsNullOrWhiteSpace(maxBackupsToStore))
            {
                MaxBackupsToStore = int.Parse(maxBackupsToStore);
            }
            if (!string.IsNullOrWhiteSpace(honourModeSaveLocation))
            {
                HonourModeSaveLocation = honourModeSaveLocation;
            }
            if (!string.IsNullOrWhiteSpace(backupSaveLocation))
            {
                BackupSaveLocation = backupSaveLocation;
            }
        }
    }
}
