using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaldursGate3HonourModeSaveManager
{
    static internal class BaldursGate3SaveFileManager
    {
        public static bool IsHonourSaveLocationValid(string honourModeSavePath)
        {
            //does path exist?
            if (Path.Exists(honourModeSavePath))
            {
                //does it have the file we expect?
                if(Directory.GetFiles(honourModeSavePath, "*.lsv").Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static BaldursGate3SaveFileManagerResult BackupCurrentSave(string honourModeSavePath, string backupPath, int maxBackupsAllowed)
        {
            BaldursGate3SaveFileManagerResult result = new BaldursGate3SaveFileManagerResult();
            result.Success = true;//default to true
            StringBuilder ErrorMessageBuilder = new StringBuilder();
            try
            {
                if (!IsHonourSaveLocationValid(honourModeSavePath))
                {
                    result.Success = false;
                    ErrorMessageBuilder.AppendLine("Honour Mode save file not found!");
                }
                if (!Path.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }
                if (result.Success.GetValueOrDefault()) //only continue if no errors
                {
                    //Copy all the files & Replaces any files with the same name
                    string backupSubFolder = Path.Combine(backupPath, DateTime.Now.ToString("yyyy-MM-dd HHmmss"));
                    Directory.CreateDirectory(backupSubFolder);
                    //should be 2 files: the lsv and a png for thumbnail
                    foreach (string honourFile in Directory.GetFiles(honourModeSavePath, "*.*"))
                    {
                        string fileName = Path.GetFileName(honourFile);
                        File.Copy(honourFile, Path.Combine(backupSubFolder, fileName), false);
                    }
                    //if we get here then the backup succeeded!
                    string[] backups = Directory.GetDirectories(backupPath);
                    List<string> backupFolders = new List<string>(backups);
                    if (backupFolders.Count > maxBackupsAllowed)
                    {
                        backupFolders.Sort();
                        while (backupFolders.Count > maxBackupsAllowed)
                        {
                            //delete the oldest back up
                            string oldestBackup = backupFolders.First();
                            Console.WriteLine($"Exceeded max backups ({maxBackupsAllowed}). Deleting oldest backup: {oldestBackup}");
                            Directory.Delete(oldestBackup, true);

                            backups = Directory.GetDirectories(backupPath);
                            backupFolders = new List<string>(backups);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                ErrorMessageBuilder.Append(ex.Message);
            }

            if (!result.Success.GetValueOrDefault())
            {
                result.ErrorMessage = ErrorMessageBuilder.ToString();
            }
            return result;
        }

        public static List<BackupSaveItem> GetBackupSaveItems(string backupPath)
        {
            List<BackupSaveItem> result  = new List<BackupSaveItem>();
            foreach (string backupDirectory in Directory.GetDirectories(backupPath))
            {
                DirectoryInfo backupInfo = new DirectoryInfo(backupDirectory);
                string iconPath = Path.Combine(backupDirectory, "HonourMode.WebP");
                System.Drawing.Image? thumbnail = null;
                if (!File.Exists(iconPath))
                {
                    iconPath = string.Empty;
                }
                else
                {
                    SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(iconPath);
                    int width = 96;
                    int height = 54;
                    SixLabors.ImageSharp.Image resized = image.Clone(x => x.Resize(width, height));
                    image.Dispose();
                    using (var outStream = new MemoryStream())
                    {
                        resized.SaveAsJpeg(outStream);
                        thumbnail = System.Drawing.Image.FromStream(outStream);
                    }
                  
                }
               
                result.Add(new BackupSaveItem
                {
                    Path = backupDirectory,
                    DateCreated = backupInfo.CreationTime,
                    IconPath = iconPath,
                    SaveThumbnail = thumbnail
                });
            }
            return result;
        }

        public static BaldursGate3SaveFileManagerResult RestoreBackup(string honourModeSavePath, string pathOfBackupToRestore)
        {
            BaldursGate3SaveFileManagerResult result = new BaldursGate3SaveFileManagerResult();
            StringBuilder ErrorMessageBuilder = new StringBuilder();
            result.Success = true;//default to true
            try
            {
                if (!IsHonourSaveLocationValid(honourModeSavePath))
                {
                    result.Success = false;
                    ErrorMessageBuilder.AppendLine("Honour Mode save file not found! Aborting restore...");
                }
                if (!Path.Exists(pathOfBackupToRestore))
                {
                    result.Success = false;
                    ErrorMessageBuilder.AppendLine("Backup save file not found! Aborting restore...");
                }
                if (result.Success.GetValueOrDefault()) //only continue if no errors
                {
                    //TO DO!
                    //CREATE BACK UP OF HONOUR MODE FILE IN CASE SOMETHING GOES WRONG!!!
                    //Save in separate "undo" slot

                    //restore the backup!
                    foreach (string backupFile in Directory.GetFiles(pathOfBackupToRestore, "*.*"))
                    {
                        string fileName = Path.GetFileName(backupFile);
                        File.Copy(backupFile, Path.Combine(honourModeSavePath, fileName), true);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                ErrorMessageBuilder.Append(ex.Message);
            }
            if (!result.Success.GetValueOrDefault())
            {
                result.ErrorMessage = ErrorMessageBuilder.ToString();
            }
            return result;

        }
    }
}
