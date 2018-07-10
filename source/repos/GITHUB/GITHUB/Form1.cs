using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;
namespace GITHUB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileSystemWatcher watcher = new FileSystemWatcher();
        private void button1_Click(object sender, EventArgs e)
        {
            watcher.Path = AppDomain.CurrentDomain.BaseDirectory;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            string gitCommand = @"C:\Program Files\Git\bin\git.exe";
            string gitInitArgument = @"push -u origin master";
            string gitRemotetArgument = @"remote";
            string gitAddArgument = @"add *";
            string gitOriginArgument = @"commit -m '13.06.2018'";
            string gitRemoteAddress = @"https://github.com/hoanglam147/EverythingNeedToCommit2.git";
            System.Diagnostics.Process.Start(gitCommand, gitAddArgument);
            
            System.Diagnostics.Process.Start(gitCommand, gitOriginArgument);
            System.Diagnostics.Process.Start(gitCommand, gitInitArgument);
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            // Begin watching.
            watcher.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            while (true) { } ;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            if (e.ChangeType.ToString() == "created")
            {

            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
           // Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
