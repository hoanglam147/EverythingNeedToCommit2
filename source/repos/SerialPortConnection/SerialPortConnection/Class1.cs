using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
namespace SerialPortConnection
{
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

        //public event EventHandler GoodReadPatternFound;
        //public event EventHandler NoReadPatternFound;
        //public event EventHandler PartialReadPatternFound;
        //public event EventHandler MultipleReadPatternFound;
        public event EventHandler OutOfOrderFound;
        public event EventHandler MissingFound;
        public string OpenEx, SendStringEx, SendByteEx, ReceipStringEx, ReceiptByteEx;
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
                OpenEx = ex.ToString();
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
                    SendStringEx = "Error opening TCP connection!";
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
                SendStringEx = ex.ToString();
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
                    SendByteEx = "Error opening TCP connection!";
                    return false;
                }
            }

            try
            {
                serialPort.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (ArgumentNullException ex)
            {
                SendByteEx += ex.ToString();
                return false;
            }
            catch (InvalidOperationException ex)
            {
                SendByteEx += ex.ToString();
                return false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                SendByteEx += ex.ToString();
                return false;
            }
            catch (ArgumentException ex)
            {
                SendByteEx += ex.ToString();
                return false;
            }
            catch (TimeoutException ex)
            {
                SendByteEx += ex.ToString();
                return false;
            }
            catch (System.Exception ex)
            {
                SendByteEx += ex.ToString();
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
                        ReceipStringEx = ex.ToString();
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
                ReceipStringEx = "You cannot read data from this stream.";
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
                        ReceiptByteEx = ex.ToString();
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
                ReceiptByteEx = "You cannot read data from this stream.";
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

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }

}
