using System;
using System.Collections.Generic;
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
        private int? _maxBackupsToSave = null;
        public int MaxBackupsToStore { get; set; }
        private string _HonourModeSaveLocation = null;
        public string HonourModeSaveLocation { get; set; }
        private string _BackupSaveLocation = null;
        public string BackupSaveLocation { get; set; }
        public bool SaveConfig()
        {
            //TO DO!
            return false;
        }
        public bool LoadConfig()
        {
            //TO DO!
            return false;
        }
    }
}
