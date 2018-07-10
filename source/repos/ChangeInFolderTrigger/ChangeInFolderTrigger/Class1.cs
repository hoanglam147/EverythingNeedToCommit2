using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
namespace ChangeInFolderTrigger
{
    

    public class FolderChange
    {


        private static bool HasChangeInDirectory = false;
        private string directory;
        private static uint bufferSize;
        private static string[] ListFileName;
        private static uint i= 0;
        public FolderChange(string path, uint t_buffer)
        {
            directory = path;
            bufferSize = t_buffer;
            ListFileName = new string[bufferSize];
        }

        public void GetEventChange()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        public bool IsHasChangeInDirectory()
        {
            return HasChangeInDirectory;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
			if(i == bufferSize) return; 
            ListFileName[i] = Path.GetFileName(e.FullPath);
            HasChangeInDirectory = true;
            i++;
        }
        public void reset_HasChangeInDirectory()
        {
            HasChangeInDirectory = false;
        }
        public string[] ListFileNameSent()
        {
            string[] ret = null;
            
            for (int k = 0;k<i;k++)
            {
                ret[k] = ListFileName[k];
            }
            return ret;
        }
    }
}
