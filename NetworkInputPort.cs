using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;

namespace NetworkNode
{
    class NetworkInputPort
    {
        public int PortID { get; set; }

        public NetworkInputPort()
        {
            Thread thread = new Thread(Listen); //tworzy nowy watek do obslugi nasluchiwania
            thread.Name = "Network Input " + PortID.ToString();
            Settings.ClientInputPortsList.Add(thread);  //dodaje wątek do listy wszystkich wątków klienckich portow wejsciowych
            thread.Start(); //uruchamia watek skok do funkcji Listen
        }

        public void Listen()
        {
            byte[] buffer = new byte[53];   //bufor na przychodzacy pakiet

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //tworzy socket do nasluchiwania

            listener.Bind(Settings.GetIP());   //przypisuje mu punkt komunikacyjny
            listener.Listen(1); //rozpoczyna nasluch

            while (true)
            {
                Socket handler = listener.Accept(); //tworzy nowy socket do obslugi przychodzacego polaczenia

                //odbieranie danych
                while (true)
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
