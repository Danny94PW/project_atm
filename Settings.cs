using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Client_Node
{
    public static class Settings
    {
        public static readonly IPAddress ip_address = IPAddress.Parse("127.0.0.1");
        public static List<Thread> _thread_list_port_in = new List<Thread>();
        public static List<ClientNode> client_nodes = new List<ClientNode>();
        public static int id_in_port_count = 0;
       

    }   
}