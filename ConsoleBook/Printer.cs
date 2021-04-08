using ConsoleLibrary.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    internal class Printer
    {
        // DATA
        private List<TableName> Tables { get; }


        // CONSTRUCTORS
        public Printer(List<TableName> inTables)
        {
            Tables = inTables;
        }

        // METHODS    
        internal void PrintTables()
        {
            Console.WriteLine("****************  TABLES ***********************");
            foreach (var _t in Tables)
            {
                Console.WriteLine("Table number: " + (int)_t + ", Table name: " + _t);
            }
        }

        /// <summary>
        ///  prints out the details for the table or list
        /// </summary>
        /// <param name="inTableNumberToken"></param>
        internal static void PrintTableRows(string inTableNumberToken)
        {
            DbAdo _dbAdo = new DbAdo();
         
            switch (inTableNumberToken)
            {
                case "0": // Author
                    {
                        // student finish this code
                        break;
                    }
                case "1": // Book
                    {

                        List<Book> _books = _dbAdo.GetBooks();
                        foreach (var item in _books)
                        {
                            Console.WriteLine($"Title: {item.Title}, Description: {item.Description},  Price: {item.Price}");
                        }
                        break;
                    }
            }

            Console.WriteLine();

        }

        internal static void FooterPrint()
        {
            Console.WriteLine("********************* Library App Console Ending  ***********************");
            Console.ReadLine();
        }

        internal static void HeaderPrint()
        {
            Console.WriteLine("********************* Library App Console Starting  ***********************");
        }

        internal static void ClearScreen()
        {
            Console.Clear();
        }


    }
}
