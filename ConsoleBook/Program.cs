using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************* Library App Console Starting  ***********************");
            Console.WriteLine("MENU OPTIONS: P print, A add, D delete, U update, Q quit and Enter");
            var _option = Console.ReadLine().ToUpper();

            while (_option != "Q") {

                switch (_option) 
                {

                    case "P": {

                        // print implementation
                        break;
                    }

                    case "A": {

                        // adding implementaton
                        break;
                    }

                    case "D": {
                        // delete implmentation
                        break;
                    }

                    case "U": {
                        // update implemtation
                        break;
                    }
                
                }
            }

            Console.WriteLine("********************* Library App Console Ending  ***********************");
            Console.ReadLine();
        }
    }
}
