using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Node
{
    class ClientPortOut : ClientPort
    {
        int out_port_number; // numer portu
        bool out_occupied; // mowi czy aktywny port

        // konstruktor wyjsciowego portu klienckiego
        public ClientPortOut(int number, bool occupied) : base(number, occupied)
        {
            out_port_number = number;
            out_occupied = occupied;
        }

        // odpalenie wątku nasłuchującego 
        public void send(string server, string message)
        {
            TcpClient client = new TcpClient();
            client.Connect(server,out_port_number);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);

            data = new Byte[256];
            String responseData = String.Empty;
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // zamknac wszystko
            stream.Close();
            client.Close();

        }

    }
}
