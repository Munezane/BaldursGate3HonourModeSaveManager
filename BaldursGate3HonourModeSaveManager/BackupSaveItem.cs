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
        public DateTime DateCreated { get; set; } = DateTime.MinValue;
        public Image? SaveThumbnail { get; set; } = null;
    }
}
