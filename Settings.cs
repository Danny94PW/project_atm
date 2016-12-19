using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace NetworkNode
{
    static class Settings
    {
        public static int routerID;

        public static List<NetworkInputPort> networkinput = new List<NetworkInputPort>();
        public static List<NetworkOutputPort> networkoutput = new List<NetworkOutputPort>();
        public static List<ClientInputPort> clientinput = new List<ClientInputPort>();
        public static List<ClientOutputPort> clientoutput = new List<ClientOutputPort>();

        //public static int NetworkInputPorts = networkinput.Count;
        //public static int NetworkOutputPorts = networkoutput.Count;
        //public static int ClientInputPorts = clientinput.Count;
        //public static int ClientOutputPorts { get; set; }

        public static IPEndPoint GetIP(int port)
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());   //pobiera nazwe hosta
            //IPAddress ipAddress = ipHostInfo.AddressList[0];    //wyciaga IP z nazwy hosta
            //IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);    //tworzy punkt komunikacyjny !!! PORT SYSTEMOWY !!!

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            return localEndPoint;
        }
    }
}
