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
        public int portID { get; set; }
        private Socket output = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public ClientOutputPort(int routerid, int portid)
        {
            portID = portid;
            Console.WriteLine("Utworzono kliencki port wyjściowy " + portID.ToString());
        }

        public void Send(int destport, byte[] data)
        {
            output.Connect(Settings.GetIP(destport));
            output.Send(data);
            Console.WriteLine("Wysłano dane z portu klienckiego " + portID.ToString());
            output.Shutdown(SocketShutdown.Both);
        }
    }
}
