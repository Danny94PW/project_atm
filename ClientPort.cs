using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Node
{
    class ClientPort
    {
         
        private int _number; // numer portu

        private bool _occupied; // mowi czy port jest aktywny TODO

        // konstruktor 0 argumentowy
        public ClientPort()
        {
            this._number = 0;
            this._occupied = false;
        }

        // konstruktor 2 argumentowy
        public ClientPort(int id, bool x)
        {
            this._number = id;
            this._occupied = x;
        }
    }
}

