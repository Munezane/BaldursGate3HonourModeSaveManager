using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldursGate3HonourModeSaveManager
{
    public class BackupSaveItem
    {
        public BackupSaveItem() { 
        
        }
        public string Path { get; set; } = string.Empty;
        public string DateCreatedString 
        {
            get {
                return DateCreated.ToString("dd/MM/yyyy HH:mm:ss");
            } 
        }
        [System.ComponentModel.Browsable(false)]
        public DateTime DateCreated { get; set; } = DateTime.MinValue;
        [System.ComponentModel.Browsable(false)]
        public string IconPath { get; set; } = string.Empty;
        [System.ComponentModel.Browsable(false)]
        public Image? SaveThumbnail { get; set; } = null;
    }
}
