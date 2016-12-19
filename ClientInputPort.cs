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
        public int systemport { get; set; }

        public ClientInputPort(int routerid, int portid)
        {
            PortID = portid;
            systemport = routerid * 10000 - portid; //obliczanie portu systemowego
            Console.WriteLine("Utworzono kliencki port wejściowy " + PortID);
            Thread thread = new Thread(Listen); //tworzy nowy watek do obslugi nasluchiwania
            thread.Start(); //uruchamia watek skok do funkcji Listen
        }

        public void Listen()
        {
            byte[] buffer = new byte[53];   //bufor na przychodzacy pakiet

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //tworzy socket do nasluchiwania

            listener.Bind(Settings.GetIP(systemport));   //przypisuje mu punkt komunikacyjny
            listener.Listen(1); //rozpoczyna nasluch

            while (true)
            {
                Socket handler = listener.Accept(); //tworzy nowy socket do obslugi przychodzacego polaczenia

                Console.WriteLine("Odbieranie...");
                //odbieranie danych
                while (true)
                {
                    handler.Receive(buffer);
                    if (buffer.Length == 53)
                    {
                        break;
                    }
                }
                Console.WriteLine("Otrzymany pakiet:/n" + Encoding.UTF8.GetString(buffer));
                SwitchingField.Switching(buffer);
            }
        }
    }
}
