using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace NetworkNode
{
    class ClientOutputPort
    {
        public int portID;

        public ClientOutputPort()
        {
            Thread thread = new Thread(Send);
            thread.Name = "Client Output " + portID.ToString();
            Settings.ClientOutputPortsList.Add(thread);
            thread.Start();
        }

        public void Send()
        {
            byte[] data = new byte[53];
            Socket output = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    //socket do laczenia sie z klientem

            output.Connect(Settings.GetIP());   //polaczenie z klientem TODO port
            output.Send(data);    //wysylanie bufora

        }
    }
}
