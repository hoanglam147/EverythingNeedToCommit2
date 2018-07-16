using System.Threading;
using DeviceConnection;
using Microsoft.Office.Interop.Excel;
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
        private string pOnCommand, pOffCommand, acquisitionTriggerCommand;
        private int pOnTime, pOffTime;
        private AcquisitionType acquisitionType;
        private ClientConnection clientConnection;
        private string IPAdrr;
        private int port;

        public volatile bool _shouldStopPhase;

        public PhaseModeTCP(string t_pOnCommand, string t_pOffCommand, AcquisitionType t_acquisitionType, string t_acquisitionTriggerCommand, int t_pOnTime, int t_pOffTime, string t_IPAdrr, int t_port)
        {
            pOnCommand = t_pOnCommand;
            pOffCommand = t_pOffCommand;
            acquisitionType = t_acquisitionType;
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
                while (_shouldStopPhase)
                {
                    clientConnection.SendString(pOnCommand);
                    Thread.Sleep(pOnTime);
                    clientConnection.SendString(pOffCommand);
                    Thread.Sleep(pOffTime);
                }
            }
            else
            {
                while (_shouldStopPhase)
                {
                    clientConnection.SendString(pOnCommand);
                    for(int i = 0;i<pOnTime/10;i++)
                    {
                        clientConnection.SendString(acquisitionTriggerCommand);
                        Thread.Sleep(pOnTime / 10);
                    }
                    clientConnection.SendString(pOffCommand);
                    Thread.Sleep(pOffTime);
                }
            }
        }
            
    }
    public class OneShotTCP
    {

    }
}
