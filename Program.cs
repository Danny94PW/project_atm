using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNode
{
    class Program
    {
        static int routerID;

        static void Main(string[] args)
        {
            try
            {
                routerID = Convert.ToInt16(args[0]);
            }
            catch
            {
                Console.WriteLine("Nieprawidłowy argument");
            }
            Console.WriteLine("Router nr " + args[0]);
            Console.ReadLine();


        }
    }
}
