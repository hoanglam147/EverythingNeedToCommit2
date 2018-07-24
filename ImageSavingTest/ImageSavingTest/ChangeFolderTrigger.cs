using System;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ImageSavingTest;
namespace ChangeInFolderTrigger
{
    
    public class FolderChangeEvent
    {
        // 
        /*--default setting for excel file--*/
        //public const  uint startRow = 5;
        //public const uint col1 = 8;
        //public const uint col2 = 9;
        /*----------------------------------*/

        //public string FileNamePush;
        private string directory;
        private static  string FileName;
        private static uint count = 0;
        public volatile bool _shouldStop;
        public volatile string RecordStringEventInFolder = "";
        public  volatile bool hasChange = false;
        //private static string pathExceFile;
        //private static uint sheetExcelIndex;
        public FolderChangeEvent(string path)
        {
            directory = path;
            FileName = "";
        }

        public void BeginWatchChangeInFolder()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileName = Path.GetFileName(e.FullPath);           
        }
        
        public void TrackingEventChangeInFolder()
        {
            string temp;
            temp = FileName;
            while (_shouldStop)
            {
                
                if (temp==FileName)
                {

                }
                else
                {
                    count++;
                    RecordStringEventInFolder = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + " New Image transfer in to folder with file name " + FileName + "; Number of image transfered: " + count.ToString();
                    temp = FileName;
                    hasChange = true;
                }
            }
            //streamWriter.Close();
        }
    }

}
