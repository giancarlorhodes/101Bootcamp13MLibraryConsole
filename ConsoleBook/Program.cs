using ConsoleLibrary.DataEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient; // needs to be added to use database Classes


namespace ConsoleLibrary
{

    

    class Program
    {
        static void Main(string[] args)
        {

                  
            Printer.HeaderPrint();

            //TODO: STEP 1 - search, login, register  - main menu

            // loop to continue until user is done
            string input;

            do
            {
                input = Printer.MainMenuPrint();

                if (input.ToLower() == "r") 
                {
                    // User Menu 

                    // add user
                    User u = Printer.CollectAddUserData();
                    DbAdo data = new DbAdo();
                    data.CreateUser(u);
                }
            } while (input.ToLower() != "q");


                // TODO: OLD REWRITE
                //string[] _tokens; // string array
                //_tokens = Printer.GetTokensImproved();

                //while (_tokens[0] != "Q")
                //{
                //    switch (_tokens[0])
                //    {
                //        // prints a generic list of the tables to operate on
                //        case "PT":
                //            {
                //                // TODO: refactor this, seems like a code smell to have to create a list and
                //                // add here? Is there a better place to move this code?
                //                List<TableName> tablesList = new System.Collections.Generic.List<TableName>();
                //                tablesList.Add(TableName.Author);
                //                tablesList.Add(TableName.Book);
                //                Printer _printer = new Printer(tablesList);
                //                _printer.PrintTables();
                //                break;
                //            }
                //        // prints out the details of the table or list
                //        case "P":
                //            {
                //                // TODO: refactor to remove the out keyword
                //                int _valueSecondToken;
                //                if (int.TryParse(_tokens[1], out _valueSecondToken))
                //                    Printer.PrintTableRows(_tokens[1]); // needs implementing
                //                break;
                //            }
                //        case "A":
                //            {
                //                // adding implementaton for SQLSSERVER DATABASE ADO.NET
                //                Console.WriteLine("adding"); // TESTING ONLY
                //                break;
                //            }
                //        case "D":
                //            {
                //                // delete implmentation  for SQLSSERVER DATABASE ADO.NET
                //                Console.WriteLine("delete");  // TESTING ONLY
                //                break;
                //            }
                //        case "U":
                //            {
                //                // update implemtation  for SQLSSERVER DATABASE ADO.NET
                //                Console.WriteLine("update");  // TESTING ONLY
                //                break;
                //            }
                //        case "C":
                //            {
                //                Printer.ClearScreen();
                //                break;
                //            }
                //    }
                //    _tokens = Printer.GetTokensImproved();
                //}

                Printer.FooterPrint();
            Console.ReadLine(); // stop program
        }
    }
}
