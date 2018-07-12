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
        private FolderChangeEvent folderChangeEvent = new FolderChangeEvent("");
        private void button1_Click(object sender, EventArgs e)
        {           
            folderChangeEvent._shouldStop = true;
        }
    }
}
