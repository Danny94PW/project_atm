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
        public static List<Thread> ClientInputPortsList;
        public static List<Thread> ClientOutputPortsList;
        public static List<Thread> NetworkInputPortsList;
        public static List<Thread> NetworkOutputPortsList;

        public static IPEndPoint GetIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());   //pobiera nazwe hosta
            IPAddress ipAddress = ipHostInfo.AddressList[0];    //wyciaga IP z nazwy hosta
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);    //tworzy punkt komunikacyjny !!! PORT SYSTEMOWY !!!

            return localEndPoint;
        }
    }
}
