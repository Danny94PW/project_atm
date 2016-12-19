using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNode
{
    class Program
    {
        

        /* args[0] - id routera
         * args[1] - ilość sieciowych portów wejściowych
         * args[2] - ilość sieciowych portów wyjściowych
         * args[3] - ilość klienckich portów wejściowych
         * args[4] - ilość klienckich portów wyjściowych
        */
        static void Main(string[] args)
        {
            Settings.routerID = Convert.ToInt16(args[0]);
            Console.Title = "ROUTER " + Settings.routerID.ToString();
            Console.WriteLine("---ROUTER " + Settings.routerID.ToString() + "---");

            #region inicjalizacja portów sieciowych

            
            for(int i=1; i<=Convert.ToInt32(args[1]); i++)
            {
                Settings.networkinput.Add(new NetworkInputPort(Convert.ToInt32(args[0]), i));
            }

           
            for (int i = 1; i <= Convert.ToInt32(args[2]); i++)
            {
                Settings.networkoutput.Add(new NetworkOutputPort(Convert.ToInt32(args[0]), i));
            }
            #endregion
            #region inicjalizacja portów klienckich

            
            for (int i = 1; i <= Convert.ToInt32(args[3]); i++)
            {
                Settings.clientinput.Add(new ClientInputPort(Convert.ToInt32(args[0]), i));
            }

            
            for (int i = 1; i <= Convert.ToInt32(args[4]); i++)
            {
                Settings.clientoutput.Add(new ClientOutputPort(Convert.ToInt32(args[0]), i));
            }
            #endregion


            //do testów
            System.Threading.Thread.Sleep(10000);
            if(Convert.ToBoolean(args[5]))
                SwitchingField.Switching(Encoding.UTF8.GetBytes("chuj"));
        }
    }
}
