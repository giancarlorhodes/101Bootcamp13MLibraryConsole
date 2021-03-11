using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************* Library App Console Starting  ***********************");
            Console.WriteLine("MENU OPTIONS: P print, A add, D delete, U update, Q quit and Enter");
            Console.WriteLine();

            var _option = Console.ReadLine().ToUpper();

            while (_option != "Q") {

                switch (_option) 
                {

                    case "P": {

                            // print implementation
                            // Console.WriteLine("print"); // TESTING ONLY
                            List<string> _ts = new System.Collections.Generic.List<string>();
                            _ts.Add(TableName.Author.ToString());
                            _ts.Add(TableName.Book.ToString());
                            Printer _printer = new Printer(_ts);
                            _printer.PrintTables();
                            break;
                    }

                    case "A": {

                            // adding implementaton for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("adding"); // TESTING ONLY
                            break;
                    }

                    case "D": {
                            // delete implmentation  for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("delete");  // TESTING ONLY
                            break;
                    }

                    case "U": {
                            // update implemtation  for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("update");  // TESTING ONLY
                            break;
                    }
                
                }
                Console.WriteLine("MENU OPTIONS: P print, A add, D delete, U update, Q quit and Enter");
                _option = Console.ReadLine().ToUpper();
                Console.WriteLine();

            }

            Console.WriteLine("********************* Library App Console Ending  ***********************");
            Console.ReadLine();
        }
    }
}
