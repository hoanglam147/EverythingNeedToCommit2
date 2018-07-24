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
        private Thread thread1, thread2, thread3;
        private FolderChangeEvent folderChangeEvent;
        private PhaseModeTCP phaseModeTCP;
        private OneShotTCP oneShotTCP;
        private volatile bool shouldStop = true;

        UInt32 onPhaseTimeVal, offPhaseTimeVal, delayOnTimeVal, delayOffTimeVal;
        UInt32 timetrigger, delayExternal;

        UInt32 Port;
        string IPAdress;

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
        private void radioImageSaving_CheckedChanged(object sender, EventArgs e)
        {
            pathTextbox.Visible = true;
            goodreadcheck.Visible = true;
            noreadcheck.Visible = true;
        }
        private void goodreadcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (goodreadcheck.Checked)
            {
                goodreadtxt.Visible = true;
            }
            else
            {
                goodreadtxt.Visible = false;
            }
        }
        private void noreadcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (noreadcheck.Checked)
            {
                noreadtxt.Visible = true;
            }
            else
            {
                noreadtxt.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            phaseModeTCP._shouldStop = false;
            Thread.Sleep(5000);
            folderChangeEvent._shouldStop = false;
            Thread.Sleep(2000);
            shouldStop = false;
            this.Close();
            
        }
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

            radioImageSaving.Checked = false;
            radioPTL.Checked = false;

            pathTextbox.Visible = false;
            goodreadcheck.Visible = false;
            noreadcheck.Visible = false;
            goodreadtxt.Visible = false;
            noreadtxt.Visible = false;
        }
        private bool isIP_PORT_Correct()
        {
            UInt16 IP1, IP2, IP3, IP4;
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
        private bool isFeartureSelect()
        {
            return (radioImageSaving.Checked || radioPTL.Checked);
        }
        private bool isSavingParameterCorrect()
        {
            bool ret;
            if(Directory.Exists(pathTextbox.Text) && (goodreadcheck.Checked || noreadcheck.Checked))
            {
                if((goodreadcheck.Checked && goodreadtxt.Text.Length ==0) || (noreadcheck.Checked && noreadtxt.Text.Length ==0))
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }      
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(nextbut.Text == "Next")
            {
                bool IPCorrect = isIP_PORT_Correct();
                bool PhaseCorrect = false, OneShotCorrect = false, ContinousCorrect = false;
                if (radioPhase.Checked)
                {
                    PhaseCorrect = isPhaseCorrect();
                }
                else if (radioOneShot.Checked)
                {
                    OneShotCorrect = isOneShotCorrect();
                }
                else
                {
                    ContinousCorrect = true;
                }

                if (IPCorrect && (PhaseCorrect || OneShotCorrect || ContinousCorrect))
                {
                    InVisibleAll();
                    groupBox1.Visible = true;
                    nextbut.Text = "Run";
                    IPAdress = textboxIP1.Text + "." + textboxIP2.Text + "." + textboxIP3.Text + "." + textboxIP4.Text;
                }
                else
                {
                    MessageBox.Show("Please fill correct information");
                }
            }
            else if(nextbut.Text == "Run")
            {
                if(!isFeartureSelect())
                {
                    MessageBox.Show("Please select feature");
                }
                else if( radioImageSaving.Checked)
                {
                    if(!isSavingParameterCorrect())
                    {
                        MessageBox.Show("Paramenter for image saving is not correct");
                    }
                    else
                    {
                        ImageSavingTest();
                    }
                }
                else
                {
                    // do nothing
                    // currently not implement
                }
            }
            else
            {

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
        private void ImageSavingTest()
        {
            folderChangeEvent = new FolderChangeEvent(pathTextbox.Text);
            folderChangeEvent._shouldStop = true;
            folderChangeEvent.BeginWatchChangeInFolder();
            thread1 = new Thread(folderChangeEvent.TrackingEventChangeInFolder);
            thread1.Start();

            if(isPhaseCorrect())
            {
                thread3 = new Thread(OutputPhase);
                thread3.Start();

                phaseModeTCP = new PhaseModeTCP(pOnCmdtxt.Text, pOffCmdtxt.Text, AcquisitionType.Continous, null, (int)onPhaseTimeVal, (int)offPhaseTimeVal, IPAdress, (int)Port);
                phaseModeTCP.InitTCPConnection();
                phaseModeTCP.goodreadPattern = goodreadtxt.Text;
                phaseModeTCP.noreadPattern = noreadtxt.Text;
                phaseModeTCP._shouldStop = true;
                thread2 = new Thread(phaseModeTCP.GenerateSignalBaseOnConfiguration);
                thread2.Start();

            }
            else if (isOneShotCorrect())
            {
                thread3 = new Thread(OutputOneShot);
                thread3.Start();

                oneShotTCP = new OneShotTCP(oneShotCmdtxt.Text, IPAdress, (int)Port);
                oneShotTCP.SetTimer((int)timetrigger);
                oneShotTCP.InitTCPConnection();
                oneShotTCP.goodreadPattern = goodreadtxt.Text;
                oneShotTCP.noreadPattern = noreadtxt.Text;
                oneShotTCP._shouldStop = true;
                thread2 = new Thread(oneShotTCP.GenerateSignalBaseOnConfiguration);
                thread2.Start();
            }
            else
            {
                // continous mode
            }

        }
        private void OutputOneShot()
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
                //if(goodreadcheck.Checked && !noreadcheck.Checked)
                //{
                //   if(oneShotTCP.goodRead == 1 && folderChangeEvent.hasChange)
                //    {
                //        oneShotTCP.goodRead = 0;
                //        folderChangeEvent.hasChange = false;
                //    }
                //   else if((oneShotTCP.goodRead == 1 && !folderChangeEvent.hasChange) || (oneShotTCP.goodRead != 1 && folderChangeEvent.hasChange))
                //    {
                //        Thread.Sleep((int)timetrigger / 2);
                //        if ((oneShotTCP.goodRead == 1 && !folderChangeEvent.hasChange) || (oneShotTCP.goodRead != 1 && folderChangeEvent.hasChange))
                //        {
                //            streamWriter.WriteLine("May has issue around phases from this point");
                //            oneShotTCP.goodRead = 0;
                //            folderChangeEvent.hasChange = false;
                //        }
                //        else
                //        {
                //            // do nothing
                //        }
                //    }
                //    else
                //    {
                //        // do nothing
                //    }
                //}
                //else if(!goodreadcheck.Checked && noreadcheck.Checked)
                //{
                //    if (oneShotTCP.goodRead == -1 && folderChangeEvent.hasChange)
                //    {
                //        oneShotTCP.goodRead = 0;
                //        folderChangeEvent.hasChange = false;
                //    }
                //    else if ((oneShotTCP.goodRead == -1 && !folderChangeEvent.hasChange) || (oneShotTCP.goodRead != 11 && folderChangeEvent.hasChange))
                //    {
                //        Thread.Sleep((int)timetrigger / 2);
                //        if((oneShotTCP.goodRead == -1 && !folderChangeEvent.hasChange) || (oneShotTCP.goodRead != 11 && folderChangeEvent.hasChange))
                //        {
                //            streamWriter.WriteLine("May has issue around phases from this point");
                //            oneShotTCP.goodRead = 0;
                //            folderChangeEvent.hasChange = false;
                //        }
                //        else
                //        {
                //            // do nothing
                //        }
                //    }
                //    else
                //    {
                //        // do nothing
                //    }
                //}
                //else
                //{
                //    // don't care
                //}
            }
            streamWriter.Close();
        }
        private void OutputPhase()
        {
            string temp1, temp2;
            StreamWriter streamWriter = new StreamWriter("Output.txt");
            temp1 = folderChangeEvent.RecordStringEventInFolder;
            temp2 = phaseModeTCP.RecordString;
            while (shouldStop)
            {

                if (folderChangeEvent.RecordStringEventInFolder != temp1)
                {
                    streamWriter.WriteLine(folderChangeEvent.RecordStringEventInFolder);
                    temp1 = folderChangeEvent.RecordStringEventInFolder;
                }
                if (phaseModeTCP.RecordString != temp2)
                {
                    streamWriter.WriteLine(phaseModeTCP.RecordString);
                    temp2 = phaseModeTCP.RecordString;
                }
                //if (goodreadcheck.Checked && !noreadcheck.Checked)
                //{
                //    if (phaseModeTCP.goodRead == 1 && folderChangeEvent.hasChange)
                //    {
                //        phaseModeTCP.goodRead = 0;
                //        folderChangeEvent.hasChange = false;
                //    }
                //    else if ((phaseModeTCP.goodRead == 1 && !folderChangeEvent.hasChange) || (phaseModeTCP.goodRead != 1 && folderChangeEvent.hasChange))
                //    {
                //        Thread.Sleep((int)timetrigger / 2);
                //        if ((phaseModeTCP.goodRead == 1 && !folderChangeEvent.hasChange) || (phaseModeTCP.goodRead != 1 && folderChangeEvent.hasChange))
                //        {
                //            streamWriter.WriteLine("May has issue around phases from this point");
                //            phaseModeTCP.goodRead = 0;
                //            folderChangeEvent.hasChange = false;
                //        }
                //        else
                //        {
                //            // do nothing
                //        }
                //    }
                //    else
                //    {
                //        // do nothing
                //    }
                //}
                //else if (!goodreadcheck.Checked && noreadcheck.Checked)
                //{
                //    if (phaseModeTCP.goodRead == -1 && folderChangeEvent.hasChange)
                //    {
                //        phaseModeTCP.goodRead = 0;
                //        folderChangeEvent.hasChange = false;
                //    }
                //    else if ((phaseModeTCP.goodRead == -1 && !folderChangeEvent.hasChange) || (phaseModeTCP.goodRead != 11 && folderChangeEvent.hasChange))
                //    {
                //        Thread.Sleep((int)timetrigger / 2);
                //        if ((phaseModeTCP.goodRead == -1 && !folderChangeEvent.hasChange) || (phaseModeTCP.goodRead != 11 && folderChangeEvent.hasChange))
                //        {
                //            streamWriter.WriteLine("May has issue around phases from this point");
                //            phaseModeTCP.goodRead = 0;
                //            folderChangeEvent.hasChange = false;
                //        }
                //        else
                //        {
                //            // do nothing
                //        }
                //    }
                //    else
                //    {
                //        // do nothing
                //    }
                //}
                //else
                //{
                //    // don't care
                //}

            }
            streamWriter.Close();
        }
    }
}
