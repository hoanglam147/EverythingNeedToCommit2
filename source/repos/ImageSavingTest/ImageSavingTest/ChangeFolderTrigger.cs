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
        public const  uint startRow = 5;
        public const uint col1 = 8;
        public const uint col2 = 9;
        /*----------------------------------*/

        public string FileNamePush;
        private string directory;
        private static  string FileName;
        public volatile bool _shouldStop;
        private static string pathExceFile;
        private static uint sheetExcelIndex;
        public FolderChangeEvent(string path)
        {
            directory = path;
        }

        public void setPathExcelFile(string t_path)
        {
            pathExceFile = t_path;
        }
        public void setSheetExcelIndex(uint t_index)
        {
            sheetExcelIndex = t_index;
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
        
        public void TrackingEventChangeInFolder()
        {
            string temp;
            uint row = startRow;
            Application excel = new Application();
            if (excel == null)
            {
                return;
            }
            Workbook excelWorkbook;
            Worksheet excelWorksheet;
            object misvalue = System.Reflection.Missing.Value;

            excelWorkbook = excel.Workbooks.Open(pathExceFile);
            excelWorksheet = excelWorkbook.Worksheets.get_Item(sheetExcelIndex);
            temp = FileName;
            while (_shouldStop)
            {
                
                if (temp==FileName)
                {

                }
                else
                {
                    excelWorksheet.Cells[row, col1] = DateTime.Now;
                    excelWorksheet.Cells[row, col2] = FileName;
                    temp = FileName;
                    row = row + 1;
                }
            }
            excelWorkbook.Close(true, misvalue, misvalue);
            excel.Quit();
        }
    }

}
