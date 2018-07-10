using System;
using System.Windows.Forms;
using SerialPortConnection;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using ChangeInFolderTrigger;
using DeviceConnection;
using NationalInstruments.DAQmx;
namespace TestFORDLL1
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

        private void button1_Click(object sender, EventArgs e)
        {
            //StreamWriter logger = null;
            //string[] listfile;
            //FolderChange x = new FolderChange("E:\\WORK\\FileZillaImages\\Device1\\Images", 100);
            //x.GetEventChange();
            //ClientConnection s1 = new ClientConnection("127.0.0.1", 51236);
            //Task DAQTask;
            //DigitalSingleChannelWriter writer = null;
            //DAQTask = new Task();
            ////DAQTask.DOChannels.CreateChannel("Dev1/port0/line0", "", ChannelLineGrouping.OneChannelForEachLine);
            //DOChannel outputChannel = DAQTask.DOChannels.CreateChannel("Dev1/port0/line0", "", ChannelLineGrouping.OneChannelForEachLine);
            //DAQTask.Start();
            //writer = new DigitalSingleChannelWriter(DAQTask.Stream);
            //writer.BeginWriteSingleSampleSingleLine(true, true, null, null);
            //Thread.Sleep(1000);
            //writer.BeginWriteSingleSampleSingleLine(true, false, null, null);
            //s1.Open();
            //while (true)
            //{
            //    x.reset_HasChangeInDirectory();
            //    s1.SendString("T1");
            //    Thread.Sleep(500);
            //    s1.SendString("abcProtocolIndexdef");
            //    Thread.Sleep(500);
            //    s1.SendString("T2");
            //    Thread.Sleep(100);


            //}
            uint milisecond = 1000;
           if(!TestID_xxx_TestPeriodicIsCorrect(milisecond))
            {
                MessageBox.Show("Timing not correct");
            }
            
        }
        // Test Periodic is correct or not
        // device is running on continous ode with periodic

        // global paramter periodic timing configuration
        
        // loop until event timing not correct
        
        // ignore check first time trigger

        private bool TestID_xxx_TestPeriodicIsCorrect(uint t_milisecond)
        {
            TimeSpan timeSpan;
            DateTime dt;
            bool isFirstTime = true;
            uint milisecond = t_milisecond;
            bool loop = true;
            Task DAQTask;
            DigitalSingleChannelReader digitalSingleChannelReader;
            bool dataOnSingleLine;

            DAQTask = new Task();
            DAQTask.DIChannels.CreateChannel("Dev1/port0/line0", "", ChannelLineGrouping.OneChannelForEachLine);
            DAQTask.SynchronizeCallbacks = true;
            digitalSingleChannelReader = new DigitalSingleChannelReader(DAQTask.Stream);
            DAQTask.Start();
            
            dt = DateTime.Now;


            while (loop)
            {
                dataOnSingleLine = digitalSingleChannelReader.ReadSingleSampleSingleLine();

                if (dataOnSingleLine == false)
                {
                    timeSpan = DateTime.Now - dt;
                    dt = DateTime.Now;
                    if (isFirstTime)
                    {
                        isFirstTime = false;
                        continue;
                    }

                    if ((timeSpan.TotalMilliseconds < milisecond - 100) || (timeSpan.TotalMilliseconds > milisecond + 100))
                    {
                        loop = false;
                    }
                    Console.WriteLine(timeSpan.TotalMilliseconds);
                    Thread.Sleep(200);
                }
                
            }
            return false;

        }
    }
}
