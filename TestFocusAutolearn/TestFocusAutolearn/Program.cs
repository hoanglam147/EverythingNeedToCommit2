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
                        logger.WriteLine(DateTime.Now.ToString("dd/MM HH:mm:ss.fff") + portLogString + replace);
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


            string command, receivestring;
            Byte[] message1, message2, message3, receivemessage, expectmessage;
            // ip address of device, configname saved on device, phase on/off command
            string Addr = args[0];
            string[] configName = { args[1], args[2] };
            string[] pOn = { args[3], args[5] };
            string[] pOff = { args[4], args[6] };

            Int32 peerPort1 = 1023;
            Int32 peerPort2 = 51236;
            // run varialbe to select config 1 or config2
            UInt32 j = 0;
            // counter to long run: max uint 64 bit x 1 seconds / phase
            UInt64 k = 0;
            // get time running for configuration from GUI
            UInt64 runTimeForConfig = (UInt64)(3600 * float.Parse(args[7]));
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

            /*----------------------------------------------------------------*/

            /*-----------------connect to host mode------------------ */
            while (!isResponseCorrect)
            {
                while(!ackGoodFlag)
                {
                    tcpclient1.Open();
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
                    if(isResponseCorrect)
                    {
                        Console.WriteLine("Enter Host Mode Error");
                        break;
                    }
                    else
                    {

                    }
                    command = "CHANGE_CFG " + configName[j%2];
                    command = command + "\n";
                    command = command + "\r";
                    Console.WriteLine(command);
                    tcpclient1.SendString(command);
                    Thread.Sleep(2000);
                    receivestring = tcpclient1.ReceiveString();
                    receivestring = receivestring.Substring(0, receivestring.Length - 1);
                    if (receivestring != "ACK")
                    {
                        ackGoodFlag = true;
                    }
                    if(ackGoodFlag)
                    {
                        Console.WriteLine("Change configuration Error");
                        Console.WriteLine("Job name may not exist");
                        break;
                    }
                    else { }
                    tcpclient1.SendBytes(message3);
                    Thread.Sleep(2000);
                    receivemessage = tcpclient1.ReceiveBytes();
                    expectmessage = new Byte[] { 0x1B, 0x5B, 0x58 };
                    for (int i = 0; i < receivemessage.Length; i++)
                    {
                        if (receivemessage[i] == expectmessage[i]) { }
                        else isResponseCorrect = true;
                    }
                    tcpclient1.Close();
                    Thread.Sleep(5000);
                    tcpclient2.Open();
                    k = 0;
                    while(k < runTimeForConfig)
                    {
                        // phase on and off
                        tcpclient2.SendString(pOn[j%2]);
                        Thread.Sleep(900);
                        tcpclient2.SendString(pOff[j%2]);
                        Thread.Sleep(100);
                        // get result
                        receivestring = tcpclient2.ReceiveString();
                        // if no read stop every thing
                        if (receivestring.Contains("noread") || receivestring.Length ==0)
                        {
                            Console.WriteLine("No read message OR no message trasmit detected");
                            Console.WriteLine("Confiuration :" + configName[j % 2] + " may has problem with the focus autolearn");
                            ackGoodFlag = true;
                            isResponseCorrect = true;
                            break;
                        }

                        k++;
                    }
                    tcpclient2.Close();
                    // if counter overflow, auto reset to zero
                    j++;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }

    }
}
