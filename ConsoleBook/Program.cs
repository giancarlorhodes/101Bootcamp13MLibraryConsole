using ConsoleLibrary.DataEntity;
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
            Printer.HeaderPrint();

            // TODO: REMOVE or cleanup or move this database code
            // DbAdo _dbAdo = new DbAdo();
            // _dbAdo.OpenCloseConnection();

            string[] _tokens; // string array
            _tokens = Printer.GetTokensImproved();

            while (_tokens[0] != "Q")
            {
                switch (_tokens[0])
                {
                    // prints a generic list of the tables to operate on
                    case "PT":
                        {
                            // TODO: refactor this, seems like a code smell to have to create a list and
                            // add here? Is there a better place to move this code?
                            List<TableName> tablesList = new System.Collections.Generic.List<TableName>();
                            tablesList.Add(TableName.Author);
                            tablesList.Add(TableName.Book);
                            Printer _printer = new Printer(tablesList);
                            _printer.PrintTables();
                            break;
                        }
                    // prints out the details of the table or list
                    case "P":
                        {
                            // TODO: refactor to remove the out keyword
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
                    case "C":
                        {
                            Printer.ClearScreen();
                            break;
                        }
                }
                _tokens = Printer.GetTokensImproved();
            }
            Printer.FooterPrint();
        }
    }
}
