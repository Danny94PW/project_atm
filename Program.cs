using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client_Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EMULATOR WEZLOW KLIECKICH");
            Console.ReadLine();

            // tworze 2 porty
            
            ClientPortIn _client_port_in = new ClientPortIn(50000,true);
            _client_port_in.startListening();

            ClientPortIn _client_port_in1 = new ClientPortIn(49999, true);
            _client_port_in1.startListening();
            
            // taka zmienna porzadkowa
            int i = 1;

            Console.WriteLine("Lista aktywnych portów wejściowych:");

            // petla ktora leci po liscie aktywnych portow i pokazuje je
            foreach (Thread t in Settings._thread_list_port_in)
            {
                Console.WriteLine("["+ i++ +"] => " + t.Name);
            }
            
            Console.ReadLine();
            ClientPortOut client_port_out = new ClientPortOut(50000, true);
            client_port_out.send(Settings.ip_address.ToString(), "uwaga robie salto!");
        }
    }
}
