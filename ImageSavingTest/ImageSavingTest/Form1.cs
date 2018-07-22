using System;
using System.Windows.Forms;
using DeviceConnection;
using System.IO;
using System.Threading;
using TriggerDeviceNameSpace;
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
        private Thread thread1, thread2, thread3;
        private FolderChangeEvent folderChangeEvent = new FolderChangeEvent("E:\\WORK\\FileZillaImages\\Device1\\Images");
        //PhaseModeTCP phaseModeTCP = new PhaseModeTCP("T1", "T2", AcquisitionType.Continous,"", 700, 10000, "192.168.1.12", 51236);
        OneShotTCP oneShotTCP = new OneShotTCP("T1", "192.168.1.12", 51236);
        private volatile bool shouldStop = true;

        private void button2_Click(object sender, EventArgs e)
        {
            oneShotTCP._shouldStop = false;
            Thread.Sleep(5000);
            folderChangeEvent._shouldStopTrackingFolder = false;
            Thread.Sleep(2000);
            shouldStop = false;
            this.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            folderChangeEvent._shouldStopTrackingFolder = true;
            folderChangeEvent.BeginWatchChangeInFolder();

            oneShotTCP._shouldStop = true;
            oneShotTCP.InitTCPConnection();
            oneShotTCP.SetTimer(10000);

            thread3 = new Thread(run);
            thread3.Start();

            thread1 = new Thread(folderChangeEvent.TrackingEventChangeInFolder);
            thread1.Start();

            thread2 = new Thread(oneShotTCP.GenerateSignalBaseOnConfiguration);
            thread2.Start();           
        }
        private void run()
        {
            string temp1, temp2;
            StreamWriter streamWriter = new StreamWriter("Output.txt");
            temp1 = folderChangeEvent.RecordStringEventInFolder;
            temp2 = oneShotTCP.RecordString;
            while (shouldStop)
            {

                if (folderChangeEvent.RecordStringEventInFolder != temp1)
                {
                    streamWriter.WriteLine(folderChangeEvent.RecordStringEventInFolder);
                    temp1 = folderChangeEvent.RecordStringEventInFolder;
                }
                if (oneShotTCP.RecordString != temp2)
                {
                    streamWriter.WriteLine(oneShotTCP.RecordString);
                    temp2 = oneShotTCP.RecordString;
                }
                if(folderChangeEvent.hasChange)
                {
                    if(oneShotTCP.goodRead)
                    {
                        oneShotTCP.goodRead = false;
                    }
                    else
                    {
                        streamWriter.WriteLine("Detect message transfer when no read detected. Error!");
                    }
                    folderChangeEvent.hasChange = false;
                }              
                else if(oneShotTCP.goodRead)
                {
                    if(!folderChangeEvent.hasChange)
                    {
                        Thread.Sleep(500);
                        if(!folderChangeEvent.hasChange)
                        {
                            streamWriter.WriteLine("Not detect image transfer when good read detected. Error!");
                        }
                    }
                    else
                    {
                        folderChangeEvent.hasChange = false;
                    }
                    oneShotTCP.goodRead = false;
                }
            }
            streamWriter.Close();
        }
    }
}
