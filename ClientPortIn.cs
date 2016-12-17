using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Node
{
    /// <summary>
    /// Klasa portu wejsciowego wezla klienckiego
    /// </summary>
    class ClientPortIn : ClientPort
    {
        Thread thread; // watek do nasluchu
        TcpListener tcp_listener; // nasluchiwacz polaczen
        int in_port_number; // numer portu
        bool in_occupied; // mowi czy aktywny port

        // konstruktor wejsciowego portu klienckiego
        public ClientPortIn(int number, bool occupied) : base(number, occupied)
        {
            in_port_number = number;
            in_occupied = occupied;
        }

        // odpalenie wątku nasłuchującego 
        public void startListening()
        {
            thread = new Thread(start);
            Settings.id_in_port_count++;
            thread.Name = in_port_number.ToString();
            thread.Start();
            Settings._thread_list_port_in.Add(thread);
        }

        // metoda wrzucana w wątek, nasłuchuje na danym ip i porcie
        public void start()
        {
            tcp_listener = new TcpListener(Settings.ip_address, in_port_number);
            tcp_listener.Start();

            Console.WriteLine("Nasluchuje na  " + Settings.ip_address + ":" + in_port_number);

            Byte[] bytes = new Byte[256];
            String data = null;
            // petla zeby się powtarzało w  kółko
            while (true)
            {
                Console.Write("[" + in_port_number + "] " + "Waiting for a connection... \n");
                

                TcpClient client = tcp_listener.AcceptTcpClient();

                Console.Write("[" + in_port_number + "] " + "Connected !  \n");

                data = null;
                NetworkStream stream = client.GetStream();
                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // transluje dane w ASCII
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);


                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Wysyła odpowiedź
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }
                client.Close();

            }
            

        }
      
    }
}
