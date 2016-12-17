using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Node
{
    public class ClientNode
    {
        public int id, inPortNetwork, inPortManager, outPortNetwork, outPortManager;
        public string ip;
        

        public ClientNode(string ID, string inNet, string outNet, string inMan, string outMan, string ip)
        {

            this.id = Int32.Parse(ID);
            this.inPortNetwork = Int32.Parse(inNet);
            this.outPortNetwork = Int32.Parse(outNet);
            this.inPortManager = Int32.Parse(inMan);
            this.outPortManager = Int32.Parse(outMan);
            this.ip = ip;
            //make_ports_alive();
           
        }
        public void make_ports_alive()
        {
            ClientPortIn inPortNet = new ClientPortIn(this.inPortNetwork, true);
            inPortNet.startListening();
            ClientPortIn inPortMan = new ClientPortIn(this.inPortManager, true);
            inPortMan.startListening();
            ClientPortOut outPortNet = new ClientPortOut(this.outPortNetwork, true);
            ClientPortOut outPortMan = new ClientPortOut(this.outPortManager, true);

        }
    }
}
