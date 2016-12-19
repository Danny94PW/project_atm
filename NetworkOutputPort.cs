using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

namespace NetworkNode
{
    class NetworkOutputPort
    { 
        public int portID { get; set; }
        private Socket output = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public NetworkOutputPort(int routerid, int portid)
        {
            portID = portid;
            Console.WriteLine("Utworzono port sieciowy wyjściowy " + portID.ToString());
            //Thread thread = new Thread(Idle);
            //thread.Name = "Network Output " + portID.ToString();
            //Settings.ClientOutputPortsList.Add(thread);
            //thread.Start();
        }

        public void Idle()
        {
            byte[] data = new byte[53]; //pojemnik na dane do wysłania

            data = Encoding.UTF8.GetBytes("blabla");    //do testów

           // Socket output = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    //socket do wysyłania danych

            Send(20001, data);  //wysyłanie data przez socket output na dany port, normalnie port będzie przekazywany przez pole komutacyjne

            //output.Connect(Settings.GetIP(port));   //polaczenie z klientem TODO port
            //output.Send(data);    //wysylanie pakietu
            //Console.WriteLine("Wyslano dane");
        }

        public void Send(int destport, byte[] data)
        {
            output.Connect(Settings.GetIP(destport));
            output.Send(data);
            Console.WriteLine("Wysłano dane z portu sieciowego " + portID.ToString());
            //output.Shutdown(SocketShutdown.Both);
        }
    }
}
