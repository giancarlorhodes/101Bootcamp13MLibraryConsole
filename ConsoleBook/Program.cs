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

            string _option;
            string[] _tokens;
            GetTokens(out _option, out _tokens);

            while (_tokens[0] != "Q")
            {

                switch (_tokens[0])
                {
                    case "PT":
                        {

                            // print implementation
                            // Console.WriteLine("print"); // TESTING ONLY
                            List<TableName> _ts = new System.Collections.Generic.List<TableName>();
                            _ts.Add(TableName.Author);
                            _ts.Add(TableName.Book);

                            Printer _printer = new Printer(_ts);
                            _printer.PrintTables();
                            break;
                        }

                    case "P":
                        {
                            int _valueSecondToken;
                            if (int.TryParse(_tokens[1], out _valueSecondToken))
                            Printer.PrintTableRows(_tokens[1]); // needs implementing
                            break;
                        }

                    case "A":
                        {
                            // adding implementaton for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("adding"); // TESTING ONLY
                            break;
                        }

                    case "D":
                        {
                            // delete implmentation  for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("delete");  // TESTING ONLY
                            break;
                        }

                    case "U":
                        {
                            // update implemtation  for SQLSSERVER DATABASE ADO.NET
                            Console.WriteLine("update");  // TESTING ONLY
                            break;
                        }

                }
                GetTokens(out _option, out _tokens);


            }

            Console.WriteLine("********************* Library App Console Ending  ***********************");
            Console.ReadLine();
        }

        private static void GetTokens(out string _option, out string[] _tokens)
        {
            Console.WriteLine("MENU: PT - print tables, P {#}, A {#} add, D {#} delete, U {#} update, Q quit. {#} is required table number argument");
            Console.WriteLine();
            _option = Console.ReadLine().ToUpper();
            _tokens = _option.Split(' ');
        }
    }
}
