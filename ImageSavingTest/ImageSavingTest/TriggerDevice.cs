using System.Threading;
using DeviceConnection;
using System.IO;
using System;
namespace TriggerDeviceNameSpace
{
    public enum AcquisitionType
    {
        External,
        Continous,
        Periodic,
        Delay
    }
    
    public class PhaseModeTCP
    {
        public volatile bool _enblae;
        private string pOnCommand, pOffCommand, acquisitionTriggerCommand;
        private int pOnTime, pOffTime;
        private static string result;
        private AcquisitionType acquisitionType;
        private ClientConnection clientConnection;
        private string IPAdrr;
        private int port;
        public volatile bool _shouldStop;
        public volatile string RecordString = "";
        public volatile string goodreadPattern, noreadPattern;
        public volatile int goodRead;

        private static uint count = 1;
        public PhaseModeTCP(string t_pOnCommand, string t_pOffCommand, AcquisitionType t_acquisitionType, string t_acquisitionTriggerCommand, int t_pOnTime, int t_pOffTime, string t_IPAdrr, int t_port)
        {
            pOnCommand = t_pOnCommand;
            pOffCommand = t_pOffCommand;
            acquisitionType = t_acquisitionType;
            acquisitionTriggerCommand = t_acquisitionTriggerCommand;
            pOnTime = t_pOnTime;
            pOffTime = t_pOffTime;
            IPAdrr = t_IPAdrr;
            port = t_port;
        }
        public bool InitTCPConnection()
        {
            clientConnection = new ClientConnection(IPAdrr, port);
            return clientConnection.Open();
        }
        public void CloseTCPConnection()
        {
            clientConnection.Close();
        }
        public void GenerateSignalBaseOnConfiguration()
        {
            if(acquisitionType != AcquisitionType.External)
            {
                while (_shouldStop)
                {
                    clientConnection.SendString(pOnCommand);
#if _enblae
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + ": Send command to on phase; Start phase: " + count.ToString();
#endif
                    Thread.Sleep(pOnTime);
                    clientConnection.SendString(pOffCommand);
#if _enblae
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + ": Send command to off phase; Stop phase: " + count.ToString();
#endif
                    Thread.Sleep(100);
#if _enblae
                    result = clientConnection.ReceiveString();
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + " Phase result message: " + result;

                    if (result.Contains(goodreadPattern))
                    {
                        goodRead = 1;
                    }
                    else if(result.Contains(noreadPattern))
                    {
                        goodRead = -1;
                    }
                    else
                    {
                        goodRead = 0;
                    }
                    count++;
#endif
                    Thread.Sleep(pOffTime - 80);
                }
            }
            else
            {
                while (_shouldStop)
                {
                    clientConnection.SendString(pOnCommand);
#if _enblae
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + ": Send command to on phase; Start phase: " + count.ToString();
#endif
                    for (int i = 0;i<pOnTime/10;i++)
                    {
                        clientConnection.SendString(acquisitionTriggerCommand);
                        Thread.Sleep(pOnTime / 10);
                    }
                    clientConnection.SendString(pOffCommand);
#if _enblae
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + ": Send command to off phase; Stop phase: " + count.ToString();
#endif
                    Thread.Sleep(20);
#if _enblae
                    result = clientConnection.ReceiveString();
                    RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + " Phase result message: " + result;
                    if (result.Contains(goodreadPattern))
                    {
                        goodRead = 1;
                    }
                    else if (result.Contains(noreadPattern))
                    {
                        goodRead = -1;
                    }
                    else
                    {
                        goodRead = 0;
                    }
                    count++;
#endif
                    Thread.Sleep(pOffTime - 25);
                    
                }
            }
        }
    }
    public class OneShotTCP
    {
        public volatile bool _enable;
        private string OneShotTCPCommand;
        private ClientConnection clientConnection;
        private string IPAdrr;
        private int port;
        private int _timer;
        private static uint count = 1;
        private static string result;

        public volatile bool _shouldStop;
        public volatile string RecordString ="";
        public volatile int goodRead;
        public volatile string goodreadPattern, noreadPattern;
        public OneShotTCP(string t_oneshot_command, string t_IP, int t_port)
        {
            OneShotTCPCommand = t_oneshot_command;
            IPAdrr = t_IP;
            port = t_port;
        }
        public void SetTimer(int t_timer)
        {
            _timer = t_timer;
        }
        public bool InitTCPConnection()
        {
            clientConnection = new ClientConnection(IPAdrr, port);
            return clientConnection.Open();
        }
        public void GenerateSignalBaseOnConfiguration()
        {
            while(_shouldStop)
            {
                clientConnection.SendString(OneShotTCPCommand);
#if _enable
                RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + ": Send OneShot Command " + count.ToString();
#endif
                Thread.Sleep(100);
#if _enable
                result = clientConnection.ReceiveString();
                RecordString = DateTime.Now.ToString("dd/MM hh:mm:sss:fff") + " Result message: " + result;

                if(result.Contains(goodreadPattern))
                {
                    goodRead = 1;
                }
                else if(result.Contains(noreadPattern))
                {
                    goodRead = -1;
                }
                else
                {
                    goodRead = 0;
                }
#endif
                Thread.Sleep(_timer -100);
                count++;
            }
        }
    }
}
