using System;
using System.Windows.Forms;
using DeviceConnection;
using System.Threading;
using System.IO;
using ChangeInFolderTrigger;
namespace ImageSavingTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private FolderChangeEvent folderChangeEvent = new FolderChangeEvent("E:\\yemp\\HOSO");
        private Thread thread1, thread2;

        private void button2_Click(object sender, EventArgs e)
        {
            folderChangeEvent._shouldStop = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            folderChangeEvent._shouldStop = true;
            folderChangeEvent.setPathExcelFile("E:\\lam\\Book1.xlsx");
            folderChangeEvent.setSheetExcelIndex(1);
            folderChangeEvent.BeginWatchChangeInFolder();
            thread1 = new Thread(folderChangeEvent.TrackingEventChangeInFolder);
            thread1.Start();
        }
    }
}
