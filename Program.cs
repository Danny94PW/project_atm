using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

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

            xmlRead();
            showMeNodes();
            
            Console.ReadLine();
            ClientPortOut client_port_out = new ClientPortOut(50000, true);
            client_port_out.send(Settings.ip_address.ToString(), "uwaga robie salto!");
        }
        static public void xmlRead()
        {
            XmlTextReader reader = new XmlTextReader("C:\\Users\\namio_000\\Documents\\Visual Studio 2015\\Projects\\Client_Node\\ClientNodeConfiguration.xml");
            
            
            while (reader.Read())
            {
                if((reader.NodeType == XmlNodeType.Element) && (reader.Name == "wezel")){

                    if (reader.HasAttributes)
                    {
                        ClientNode tempNode = new ClientNode(reader.GetAttribute(0), reader.GetAttribute(1), reader.GetAttribute(2), reader.GetAttribute(3), reader.GetAttribute(4), reader.GetAttribute(5));
                        Settings.client_nodes.Add(tempNode);
                    }
                }
            }
        }
        
        static public void showMeNodes()
        {
            Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-LISTA WEZLOW-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            foreach (ClientNode tempClient in Settings.client_nodes)
            {
                Console.WriteLine("ID:" + tempClient.id+" InPortNetwork:"+tempClient.inPortNetwork+" InPortManager:"+tempClient.inPortManager + " OutPortNetwork:" + tempClient.outPortNetwork + " OutPortManager:" + tempClient.outPortManager +"\nIpAddress:"+tempClient.ip);
                if (tempClient.id < Settings.client_nodes.Count)
                {
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
        }

    }
}
