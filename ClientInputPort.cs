using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetworkNode
{
    class ClientInputPort
    {
        public int PortID { get; set; }

        public ClientInputPort()
        {
            Thread thread = new Thread(Listen); //tworzy nowy watek do obslugi nasluchiwania
            thread.Start(); //uruchamia watek skok do funkcji Listen
        }

        public void Listen()
        {
            byte[] buffer = new byte[53];   //bufor na przychodzacy pakiet

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());   //pobiera nazwe hosta
            IPAddress ipAddress = ipHostInfo.AddressList[0];    //wyciaga IP z nazwy hosta
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);    //tworzy punkt komunikacyjny !!! PORT SYSTEMOWY !!!

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //tworzy socket do nasluchiwania

            listener.Bind(localEndPoint);   //przypisuje mu punkt komunikacyjny
            listener.Listen(1); //rozpoczyna nasluch

            while(true)
            {
                Socket handler = listener.Accept(); //tworzy nowy socket do obslugi przychodzacego polaczenia

                //odbieranie danych
                while(true)
                {
                    handler.Receive(buffer);
                    if (buffer.Length == 53)
                    {
                        break;
                    }
                }
                

            }
        }
    }
}
