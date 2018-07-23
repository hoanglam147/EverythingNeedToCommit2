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
            pOnCmdtxt.Visible = false;
            pOffCmdtxt.Visible = false;
            onPhaseTimetxt.Visible = false;
            offPhaseTimetxt.Visible = false;
            onPhaseTimetxt.Visible = false;
            offPhaseTimetxt.Visible = false;
            checkPhaseDelay.Visible = false;
            oneShotCmdtxt.Visible = false;
            timingOneShottxt.Visible = false;
            checkOneShotDelay.Visible = false;
            delaypOn.Visible = false;
            delaypOff.Visible = false;
            delayOneShot.Visible = false;
            groupBox1.Visible = false;
        }
        private void radioPhase_CheckedChanged(object sender, EventArgs e)
        {
            //if(radioPhase.Checked)
            {
                pOnCmdtxt.Visible = true;
                pOffCmdtxt.Visible = true;
                onPhaseTimetxt.Visible = true;
                offPhaseTimetxt.Visible = true;
                checkPhaseDelay.Visible = true;
                oneShotCmdtxt.Visible = false;
                timingOneShottxt.Visible = false;
                checkOneShotDelay.Visible = false;
                delayOneShot.Visible = false;
                checkPhaseDelay.Checked = false;
            }
        }
        private void radioOneShot_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioOneShot.Checked)
            {
                pOnCmdtxt.Visible = false;
                pOffCmdtxt.Visible = false;
                onPhaseTimetxt.Visible = false;
                offPhaseTimetxt.Visible = false;
                checkPhaseDelay.Visible = false;
                delaypOn.Visible = false;
                delaypOff.Visible = false;

                oneShotCmdtxt.Visible = true;
                timingOneShottxt.Visible = true;
                checkOneShotDelay.Visible = true;
                checkOneShotDelay.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioContinous.Checked)
            {
                pOnCmdtxt.Visible = false;
                pOffCmdtxt.Visible = false;
                onPhaseTimetxt.Visible = false;
                offPhaseTimetxt.Visible = false;
                checkPhaseDelay.Visible = false;
                delaypOn.Visible = false;
                delaypOff.Visible = false;
                oneShotCmdtxt.Visible = false;
                timingOneShottxt.Visible = false;
                checkOneShotDelay.Visible = false;
                delayOneShot.Visible = false;
            }
        }

        private void checkPhaseDelay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPhaseDelay.Checked)
            {
                delaypOn.Visible = true;
                delaypOff.Visible = true;
            }
            else
            {
                delaypOn.Visible = false;
                delaypOff.Visible = false;
            }
        }

        private void checkOneShotDelay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOneShotDelay.Checked)
            {
                delayOneShot.Visible = true;
            }
            else
            {
                delayOneShot.Visible = false;
            }
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





        UInt32 onPhaseTimeVal, offPhaseTimeVal, delayOnTimeVal, delayOffTimeVal;
        UInt32 timetrigger, delayExternal;
        private void InVisibleAll()
        {
            pOnCmdtxt.Visible = false;
            pOffCmdtxt.Visible = false;
            onPhaseTimetxt.Visible = false;
            offPhaseTimetxt.Visible = false;
            onPhaseTimetxt.Visible = false;
            offPhaseTimetxt.Visible = false;
            checkPhaseDelay.Visible = false;
            oneShotCmdtxt.Visible = false;
            timingOneShottxt.Visible = false;
            checkOneShotDelay.Visible = false;
            delaypOn.Visible = false;
            delaypOff.Visible = false;
            delayOneShot.Visible = false;
            radioPhase.Visible = false;
            radioOneShot.Visible = false;
            radioContinous.Visible = false;
        }
        private bool isIP_PORT_Correct()
        {
            UInt16 IP1, IP2, IP3, IP4;
            UInt32 Port;
            bool ret = true;
            bool isNumber_IP1 = UInt16.TryParse(textboxIP1.Text, out IP1);
            bool isNumber_IP2 = UInt16.TryParse(textboxIP2.Text, out IP2);
            bool isNumber_IP3 = UInt16.TryParse(textboxIP3.Text, out IP3);
            bool isNumber_IP4 = UInt16.TryParse(textboxIP4.Text, out IP4);
            bool isPortNumber = UInt32.TryParse(textboxport.Text, out Port);
            if(isNumber_IP1 == false || isNumber_IP2 == false || isNumber_IP3 == false || isNumber_IP4 == false || isPortNumber == false)
            {
                ret = false;
            }
            if(IP1<0 || IP1 > 255 || IP2 < 0 || IP2 > 255 || IP3 < 0 || IP3 > 255 || IP4 < 0 || IP4 > 255)
            {
                ret = false;
            }

            return ret;
        }



        private bool isPhaseCorrect()
        {
            bool ret = true;

            bool onPhaseTime = UInt32.TryParse(onPhaseTimetxt.Text, out onPhaseTimeVal);
            bool offPhaseTime = UInt32.TryParse(offPhaseTimetxt.Text, out offPhaseTimeVal);
            bool delayOnTime = UInt32.TryParse(delaypOn.Text, out delayOnTimeVal);
            bool delayOffTime = UInt32.TryParse(delaypOff.Text, out delayOffTimeVal);
            if (pOnCmdtxt.Text.Length == 0 || pOffCmdtxt.Text.Length ==0 || onPhaseTime == false || offPhaseTime == false)
            {
                ret = false;
            }
            if (checkPhaseDelay.Checked && (delayOnTime == false || delayOffTime == false) )
            {
                ret = false;
            }

            return ret;
        }
        private bool isOneShotCorrect()
        {
            bool ret = true;

            bool TimeTriggerCorrect = UInt32.TryParse(timingOneShottxt.Text, out timetrigger);
            bool delayExternalCorrect = UInt32.TryParse(delayOneShot.Text, out delayExternal);
            if(oneShotCmdtxt.Text.Length == 0 || TimeTriggerCorrect == false)
            {
                ret = false;
            }
            if(checkOneShotDelay.Checked && delayExternalCorrect == false)
            {
                ret = false;
            }
            return ret;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool IPCorrect = isIP_PORT_Correct();
            bool PhaseCorrect = false, OneShotCorrect = false, ContinousCorrect = false;
            if(radioPhase.Checked)
            {
                PhaseCorrect = isPhaseCorrect();
            }
            else if(radioOneShot.Checked)
            {
                OneShotCorrect = isOneShotCorrect();
            }
            else
            {
                ContinousCorrect = true;
            }

            if(IPCorrect && (PhaseCorrect || OneShotCorrect || ContinousCorrect))
            {
                InVisibleAll();
                groupBox1.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Please fill correct information");
            }
            //folderChangeEvent._shouldStopTrackingFolder = true;
            //folderChangeEvent.BeginWatchChangeInFolder();

            //oneShotTCP._shouldStop = true;
            //oneShotTCP.InitTCPConnection();
            //oneShotTCP.SetTimer(10000);

            //thread3 = new Thread(run);
            //thread3.Start();

            //thread1 = new Thread(folderChangeEvent.TrackingEventChangeInFolder);
            //thread1.Start();

            //thread2 = new Thread(oneShotTCP.GenerateSignalBaseOnConfiguration);
            //thread2.Start();           
        }

        private void textboxIP1_TextChanged(object sender, EventArgs e)
        {

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
