using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace HMPAuto1
{


    class ClientConnection
    {
        public string name;
        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        public Int32 peerPort;
        public string peerAddr;

        public ClientConnection(string ipAddr, Int32 port)
        {
            peerPort = port;
            peerAddr = ipAddr;
        }
        public bool Open()
        {
            bool rc = true;
            if (tcpClient == null)
                tcpClient = new TcpClient();
            int count = 0;
            while (tcpClient.Connected == false && count < 20)
            {
                count++;
                try
                {
                    tcpClient.Connect(peerAddr, peerPort);
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                }
                if (tcpClient == null)
                    return false;
                if (tcpClient.Connected)
                    break;
                System.Threading.Thread.Sleep(500);
            }
            if (tcpClient.Connected == false)
                return false;

            // Get a client stream for reading and writing.
            tcpStream = tcpClient.GetStream();
            return rc;
        }
        public void Close()
        {
            if (tcpStream != null)
                tcpStream.Close();
            tcpStream = null;
            if (tcpClient != null)
                tcpClient.Close();
            tcpClient = null;
        }

        public bool SendString(string msg2send)
        {
            if (tcpClient == null /*|| tcpClient.Connected == false*/)
            {
                if (Open() == false)
                {
                    //MessageBox.Show("Error opening TCP connection!");
                    return false;
                }
            }

            if (tcpStream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(msg2send);
                try
                {
                    tcpStream.Write(sendBytes, 0, sendBytes.Length);
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("You cannot write data to this stream.");
                return false;
            }
            return true;
        }
        public bool SendBytes(Byte[] sendBytes)
        {
            if (tcpClient == null /*|| tcpClient.Connected == false*/)
            {
                if (Open() == false)
                {
                    //MessageBox.Show("Error opening TCP connection!");
                    Console.WriteLine("Error opening TCP connection!");
                    return false;
                }
            }

            if (tcpStream.CanWrite)
            {
                try
                {
                    tcpStream.Write(sendBytes, 0, sendBytes.Length);
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("You cannot write data to this stream.");
                Console.WriteLine("You cannot write data to this stream.");
                return false;
            }
            return true;
        }

        public string ReceiveString()
        {
            if (tcpStream == null)
                return string.Empty;

            string recv = string.Empty;

            if (tcpStream.CanRead)
            {
                int recvlen = 0;

                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                try
                {
                    // Read can return anything from 0 to numBytesToRead. 
                    // This method blocks until at least one byte is read.
                    // Or timeout (500mSec) elapses.
                    tcpStream.ReadTimeout = 50;
                    recvlen = tcpStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                }
                catch (System.IO.IOException) { }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return string.Empty;
                }

                if (recvlen > 0)
                {
                    recv = Encoding.UTF8.GetString(bytes);
                    int len = recv.IndexOf('\0');
                    recv = recv.Substring(0, len);
                }
                return recv;
            }
            else
            {
                //MessageBox.Show("You cannot read data from this stream.");
            }

            return string.Empty;
        }
        public Byte[] ReceiveBytes()
        {
            if (tcpStream == null)
                return null;

            string recv = string.Empty;

            if (tcpStream.CanRead)
            {
                int recvlen = 0;

                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                try
                {
                    // Read can return anything from 0 to numBytesToRead. 
                    // This method blocks until at least one byte is read.
                    // Or timeout (500mSec) elapses.
                    tcpStream.ReadTimeout = 40000;
                    recvlen = tcpStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                }
                catch (System.IO.IOException) { }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return null;
                }
                if (recvlen > 0)
                {
                    byte[] recvmsg = new byte[recvlen];
                    for (int i = 0; i < recvlen; i++)
                        recvmsg[i] = bytes[i];
                    return recvmsg;
                }
                return null;
            }
            else
            {
                //MessageBox.Show("You cannot read data from this stream.");
            }
            return null;
        }
    }
    public class SerialPortListener : IDisposable
    {
        public string portName;
        public int baudRate;
        public Parity parity;
        public int dataBits;
        public StopBits stopBits;
        public Handshake handshake;

        public string goodreadPattern;
        public string noreadPattern;
        public string partialreadPattern;
        public string multiplereadPattern;
        public string phaseIdSeparator;

        public List<Int32> missingPhaseIdxList;
        public List<Int32> outoforderPhaseIdxList;

        public event EventHandler GoodReadPatternFound;
        public event EventHandler NoReadPatternFound;
        public event EventHandler PartialReadPatternFound;
        public event EventHandler MultipleReadPatternFound;
        public event EventHandler OutOfOrderFound;
        public event EventHandler MissingFound;

        public SerialPortListener(string portname,
                                    int baudrate,
                                    Parity parityval,
                                    int databits,
                                    StopBits stopbits,
                                    Handshake flowcontrol,
                                    StreamWriter logger)
        {
            serialReceive = false;
            portName = portname;
            baudRate = baudrate;
            parity = parityval;
            dataBits = databits;
            stopBits = stopbits;
            handshake = flowcontrol;
            missingPhaseIdxList = new List<Int32>();
            outoforderPhaseIdxList = new List<Int32>();
            this.logger = logger;
            portLogString = " - Serial " + portName + ") - ";
        }

        public void SetPatterns(string goodreadpatt,
                                string noreadpatt,
                                string partialreadpatt,
                                string multiplereadpatt,
                                string phaseanalysispatt)
        {
            goodreadPattern = WildcardToRegex(goodreadpatt);
            noreadPattern = WildcardToRegex(noreadpatt);
            partialreadPattern = WildcardToRegex(partialreadpatt);
            multiplereadPattern = WildcardToRegex(multiplereadpatt);
            phaseIdSeparator = phaseanalysispatt;

            //goodReadRGX = new Regex(goodreadPattern, RegexOptions.IgnoreCase);
            //noReadRGX = new Regex(noreadPattern, RegexOptions.IgnoreCase);
            //partialReadRGX = new Regex(partialreadPattern, RegexOptions.IgnoreCase);
            //multipleReadRGX = new Regex(multiplereadPattern, RegexOptions.IgnoreCase);
        }

        public bool Open()
        {
            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                serialPort.Open();
                serialReceive = true;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return serialReceive;
        }

        public void Close()
        {
            serialReceive = false;
            if (serialPort != null)
                serialPort.Close();
        }

        public bool SendString(string msg2send)
        {
            if (serialPort == null || serialPort.IsOpen == false)
            {
                if (Open() == false)
                {
                    //MessageBox.Show("Error opening TCP connection!");
                    return false;
                }
            }

            Byte[] sendBytes = Encoding.UTF8.GetBytes(msg2send);
            try
            {
                serialPort.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool SendBytes(Byte[] sendBytes)
        {
            if (serialPort == null || serialPort.IsOpen == false)
            {
                if (Open() == false)
                {
                    //MessageBox.Show("Error opening TCP connection!");
                    return false;
                }
            }

            try
            {
                serialPort.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (ArgumentNullException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (TimeoutException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public string ReceiveString()
        {
            if (serialPort == null)
                return string.Empty;

            string recv = string.Empty;

            if (serialPort.IsOpen)
            {
                int recvlen = 0;

                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[serialPort.ReadBufferSize];
                bool somethingtoread = true;
                while (somethingtoread)
                {
                    try
                    {
                        // Read can return anything from 0 to numBytesToRead. 
                        // This method blocks until at least one byte is read.
                        // Or timeout (500mSec) elapses.
                        serialPort.ReadTimeout = 500;
                        recvlen = serialPort.Read(bytes, 0, serialPort.ReadBufferSize);
                    }
                    catch (TimeoutException)
                    {
                        somethingtoread = false;
                    }
                    catch (System.IO.IOException) { }
                    catch (System.Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        return string.Empty;
                    }
                }

                if (recvlen > 0)
                {
                    recv = Encoding.UTF8.GetString(bytes);
                    int len = recv.IndexOf('\0');
                    recv = recv.Substring(0, len);
                }
                return recv;
            }
            else
            {
                //MessageBox.Show("You cannot read data from this stream.");
            }

            return string.Empty;
        }

        public Byte[] ReceiveBytes(int timeout = 0)
        {
            if (serialPort == null)
                return null;

            string recv = string.Empty;

            if (serialPort.IsOpen)
            {
                int recvlen = 0;

                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[serialPort.ReadBufferSize];
                bool somethingtoread = true;
                while (somethingtoread)
                {
                    try
                    {
                        // Read can return anything from 0 to numBytesToRead. 
                        // This method blocks until at least one byte is read.
                        // Or timeout (500mSec) elapses.
                        if (timeout < 500)
                            timeout = 500;
                        serialPort.ReadTimeout = timeout;
                        recvlen += serialPort.Read(bytes, recvlen, serialPort.ReadBufferSize - recvlen);
                    }
                    catch (TimeoutException)
                    {
                        somethingtoread = false;
                    }
                    catch (System.IO.IOException) { }
                    catch (System.Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        return null;
                    }
                }
                if (recvlen > 0)
                {
                    byte[] recvmsg = new byte[recvlen];
                    for (int i = 0; i < recvlen; i++)
                        recvmsg[i] = bytes[i];
                    return recvmsg;
                }
                return null;
            }
            else
            {
                //MessageBox.Show("You cannot read data from this stream.");
            }
            return null;
        }

        public void ManageSerialPort()
        {
            Open();
            while (serialReceive)
            {
                try
                {
                    string message = serialPort.ReadLine();
                    if (logger != null)
                    {
                        string replace = String.Concat(message.Select(c => Char.IsControl(c) ?
                                                                     String.Format("[{0:X2}]", (int)c) :
                                                                     c.ToString()));
                        logger.WriteLine(DateTime.Now.Millisecond.ToString("yy/MM/dd HH:mm:ss:fff") + portLogString + replace);
                        logger.Flush();
                    }
                    //if (goodReadRGX.IsMatch(message))
                    //{
                    //    GoodReadPatternFound(this, EventArgs.Empty);
                    //}
                    //if (noReadRGX.IsMatch(message))
                    //{
                    //    NoReadPatternFound(this, EventArgs.Empty);
                    //}
                    //if (partialReadRGX.IsMatch(message))
                    //{
                    //    PartialReadPatternFound(this, EventArgs.Empty);
                    //}
                    //if (multipleReadRGX.IsMatch(message))
                    //{
                    //    MultipleReadPatternFound(this, EventArgs.Empty);
                    //}
                    // Split string on separator.
                    // ... This will separate all the words.
                    string[] fields = message.Split(phaseIdSeparator.ToCharArray());
                    if (fields.Length > 1)
                    {
                        int phaseId = Convert.ToInt32(fields[0]);
                        if (isFirstPhase)
                        {
                            isFirstPhase = false;
                        }
                        else
                        {
                            if (phaseId > expectedPhaseIdx)
                            {
                                // this is a idx hole - perhaps it will arrive later on
                                for (; phaseId == expectedPhaseIdx; expectedPhaseIdx++)
                                {
                                    missingPhaseIdxList.Add(expectedPhaseIdx);
                                    MissingFound(this, EventArgs.Empty);
                                }
                            }
                            if (phaseId < expectedPhaseIdx)
                            {
                                // this is an out-of-order situation
                                // remove this PhaseId from missing list and add it to the out-of-order list
                                for (int i = 0; i < missingPhaseIdxList.Count; i++)
                                {
                                    if (missingPhaseIdxList[i] == phaseId)
                                    {
                                        missingPhaseIdxList.Remove(i);
                                        break;
                                    }
                                }
                                outoforderPhaseIdxList.Add(phaseId);
                                OutOfOrderFound(this, EventArgs.Empty);
                            }
                        }
                        expectedPhaseIdx = phaseId + 1;
                    }
                }
                catch (TimeoutException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                catch (Exception)
                {
                    // channel closed
                }
            }
            Close();
        }

        private SerialPort serialPort;
        private Queue<byte> receivedData = new Queue<byte>();
        // private Regex goodReadRGX, noReadRGX, partialReadRGX, multipleReadRGX;
        private bool serialReceive;
        private Int32 expectedPhaseIdx = 1;
        private bool isFirstPhase = true;
        private StreamWriter logger;
        private string portLogString;

        private string WildcardToRegex(string pattern)
        {
            return "^";
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = new StreamWriter("result.txt");
            
            string command, receivestring;
            Byte[] message1, message2, message3, receivemessage, expectmessage;
            // ip address of device, configname saved on device, phase on/off command
            string Addr = args[0];
            string[] configName = { args[1], args[2] };
            string[] pOn = { args[3], args[5] };
            string[] pOff = { args[4], args[6] };
            int pOnTime = int.Parse(args[8]);
            int pOffTime = int.Parse(args[9]);

            //string Addr = "192.168.1.164";
            //string[] configName = { "cfg1", "cfg2" };
            //string[] pOn = { "T11", "T12" };
            //string[] pOff = { "T21", "T22" };
            //int pOnTime = 300;
            //int pOffTime = 100;


            Int32 peerPort1 = 1023;
            Int32 peerPort2 = 51236;
            // run varialbe to select config 1 or config2
            UInt32 j = 0;
            // counter to long run: max uint 64 bit x 1 seconds / phase
            UInt64 k = 0;
            // get time running for configuration from GUI (minute)
            UInt64 runTimeForConfig = 1000* (60 * UInt64.Parse(args[7])) / (UInt64)(pOnTime+pOffTime);
            // good read flag signal when change configure by host mode (reverse)
            bool ackGoodFlag = false;
            // flag indicate host mode enter and exit correct (reverse)
            bool isResponseCorrect = false;
            // list byte send to enter and exit host mode
            message1 = new Byte[] { 0x1B, 0x5B, 0x43, 0x0D }; // [ESC]C
            message2 = new Byte[] { 0x1B, 0x5B, 0x42, 0x0D }; // [ESC]B
            message3 = new Byte[] { 0x1B, 0x5B, 0x41, 0x0D }; // [ESC]A
            command = "";

            /*---------------INIT 2 CLIENT CONNECTION TO DEVICE---------------------------*/
            ClientConnection tcpclient1 = new ClientConnection(Addr, peerPort1);
            ClientConnection tcpclient2 = new ClientConnection(Addr, peerPort2);

            /*----------------------Open port 1023 & 51236----------------------------*/
            tcpclient1.Open();
            tcpclient2.Open();

            Console.WriteLine("***************Welcome***************");
            Console.WriteLine("This console window should not close by click X icon!!!");
            Console.WriteLine("Currently this tool can only close when have noread or no message trasmitted");
            Console.WriteLine("***************End***************");

            /*-----------------connect to host mode------------------ */
            Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") +  ": Entering Host Mode, should not close this window!!!");
            file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Entering Host Mode, should not close this window!!!");
            tcpclient1.SendBytes(message1);
            Thread.Sleep(2000);
            receivemessage = tcpclient1.ReceiveBytes();
            expectmessage = new Byte[] { 0x1B, 0x48, 0x0D, 0x0A };

            for (int i = 0; i < receivemessage.Length; i++)
            {
                if (receivemessage[i] == expectmessage[i]) { }
                else isResponseCorrect = true;
            }

            tcpclient1.SendBytes(message2);
            Thread.Sleep(2000);
            receivemessage = tcpclient1.ReceiveBytes();
            expectmessage = new Byte[] { 0x1B, 0x53, 0x0D, 0x0A };
            for (int i = 0; i < receivemessage.Length; i++)
            {
                if (receivemessage[i] == expectmessage[i]) { }
                else isResponseCorrect = true;
            }
            if (isResponseCorrect)
            {
                Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Enter Host Mode Error!!!");
                file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Enter Host Mode Error!!!");
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Enter Host Mode Succesfully!");
                file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Enter Host Mode Succesfully!");
            }

            while (!isResponseCorrect  )
            {
                while(!ackGoodFlag  )
                {
                    Console.Write(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": ");
                    file.Write(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": ");
                    
                    command = "CHANGE_CFG " + configName[j%2];
                    command = command + "\n";
                    command = command + "\r";
                    Console.WriteLine("CHANGE_CFG " + configName[j % 2] +  "; Change counter: " + j);
                    file.WriteLine("CHANGE_CFG " + configName[j % 2] + "; Change counter: " + j);
                    tcpclient1.SendString(command);
                    Thread.Sleep(2000);
                    receivestring = tcpclient1.ReceiveString();
                    receivestring = receivestring.Substring(0, receivestring.Length - 1);
                    // check error when change configuration
                    if (receivestring != "ACK")
                    {
                        ackGoodFlag = true;
                        Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Change configuration error. Job name may not exist!!!");
                        file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Change configuration error. Job name may not exist!!!");
                        isResponseCorrect = true;
                        break;
                    }

                    // delay after change config successfully
                    Thread.Sleep(5000);
                    Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Change configuration sucessfully done. Run " + configName[j%2]);
                    file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Change configuration sucessfully done. Run " + configName[j % 2]);
                    // loop until the time end
                    while (k < runTimeForConfig)
                    {
                        // phase on and off
                        tcpclient2.SendString(pOn[j%2]);
                        Thread.Sleep(pOnTime);
                        tcpclient2.SendString(pOff[j%2]);
                        Thread.Sleep(pOffTime);
                        // get result
                        receivestring = tcpclient2.ReceiveString();
                        // if no read stop every thing
                        if (receivestring.Contains("noread"))
                        {
                            Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": No read message detected!!!");
                            Console.SetCursorPosition(20,Console.CursorTop);
                            Console.WriteLine("At the " + (j + 1) + "th of changing configuration, issue occur");
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.WriteLine("The current configuration is :" + configName[j % 2]);
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.WriteLine("Total running time of device: " + ((float)(j * UInt32.Parse(args[7])) + ((float)k / (float)runTimeForConfig) * float.Parse(args[7])) + " minutes");

                            file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": No read message detected!!!");
                            file.WriteLine("At the " + (j + 1) + "th of changing configuration, issue occur");
                            file.WriteLine("The current configuration is :" + configName[j % 2]);
                            file.WriteLine("Total running time of device: " + ((float)(j * UInt32.Parse(args[7])) + ((float)k / (float)runTimeForConfig) * float.Parse(args[7])) + " minutes");


                            ackGoodFlag = true;
                            isResponseCorrect = true;
                            break;
                        }
                        else if (receivestring.Length == 0)
                        {
                            Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": No message trasmit detected!!!");
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.WriteLine("At the " + (j + 1) + "th of changing configuration, issue occur");
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.WriteLine("The current configuration is :" + configName[j % 2]);
                            Console.SetCursorPosition(20, Console.CursorTop);
                            Console.WriteLine("Total running time of device: " + ((float)(j * UInt32.Parse(args[7])) + ((float)k / (float)runTimeForConfig) * float.Parse(args[7])) + " minutes");

                            file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": No message trasmit detected!!!");
                            file.WriteLine("At the " + (j + 1) + "th of changing configuration, issue occur");
                            file.WriteLine("The current configuration is :" + configName[j % 2]);
                            file.WriteLine("Total running time of device: " + ((float)(j * UInt32.Parse(args[7])) + ((float)k / (float)runTimeForConfig) * float.Parse(args[7])) + " minutes");


                            ackGoodFlag = true;
                            isResponseCorrect = true;
                            break;
                        }
                        else
                        {
                            // do nothing
                        }
                        k++;
                    }
                    k = 0;
                    // if counter overflow, auto reset to zero
                    j++;
                    
                }
            }

            // exit host mode after detect "noread" or no message transmit
            isResponseCorrect = false;
            Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exiting host mode...");
            file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exiting host mode...");
            tcpclient1.SendBytes(message3);
            Thread.Sleep(2000);
            receivemessage = tcpclient1.ReceiveBytes();
            expectmessage = new Byte[] { 0x1B, 0x5B, 0x58 };
            for (int i = 0; i < receivemessage.Length; i++)
            {
                if (receivemessage[i] == expectmessage[i]) { }
                else
                {
                    isResponseCorrect = true;
                    Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exit Host Mode Error, please exit manualy!");
                    file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exit Host Mode Error, please exit manualy!");
                }
            }
            if(!isResponseCorrect)
            {
                Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exited host mode sucessfully.");
                file.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Exited host mode sucessfully.");
            }
            tcpclient1.Close();
            tcpclient2.Close();
            Console.WriteLine(DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff") + ": Press any key to exit...");
            file.Close();
            Console.ReadLine();

        }

    }
}
