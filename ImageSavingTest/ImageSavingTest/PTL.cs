using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceConnection;
namespace OUT
{
    enum DataCollectionType
    {
        collectiion,
        combination,
        presenttation,
        match
    }
    enum Analysis
    {
        WithinPhase,
        WithinImgae
    }
    enum SendDataOn
    {
        PhaseOff,
        AnalysisComplete,
        OnEvent,
        PhaseOnDelay
    }
    class PTL
    {
        private uint timeReceiveMessage;
        private Analysis analysis;
        private DataCollectionType dataCollectionType;
        private SendDataOn sendDataOn;
        private string IP;
        private int port;
        private ClientConnection clientConnection;
        public bool InitConnection()
        {
            clientConnection = new ClientConnection(IP, port);
            return clientConnection.Open();
        }
        public string GetResultOnEthernet()
        {
            string result = clientConnection.ReceiveString();
            return result;
        }
    }
}
