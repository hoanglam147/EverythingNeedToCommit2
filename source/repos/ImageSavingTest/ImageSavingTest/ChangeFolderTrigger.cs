using System;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ImageSavingTest;
namespace ChangeInFolderTrigger
{
    

    public class FolderChangeEvent
    {
        public  string FileNamePush;
        private string directory;
        private static  string FileName;
        public volatile bool _shouldStop;
        public FolderChangeEvent(string path)
        {
            directory = path;
        }

        public void BeginWatchChangeInFolder()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
            
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileName = Path.GetFileName(e.FullPath);
        }
        public void TrackingEventChangeInFolder(string t_path, Int16 t_index)
        {
            Application excel = new Application();
            if (excel == null)
            {
                return;
            }
            Workbook excelWorkbook;
            Worksheet excelWorksheet;
            object misvalue = System.Reflection.Missing.Value;

            excelWorkbook = excel.Workbooks.Open(t_path);
            excelWorksheet = excelWorkbook.Worksheets.get_Item(t_index);

            while (_shouldStop)
            {
                
            }
        }
    }

}
