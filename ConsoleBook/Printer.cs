using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    internal class Printer
    {

        public List<TableName> Tables { get; }

        public Printer(List<TableName> ts)
        {
            Tables = ts;
        }

        internal void PrintTables()
        {
            Console.WriteLine("****************  TABLES ***********************");
            foreach (var _t in Tables)
            {
                Console.WriteLine("Table number: " + (int)_t + ", Table name: " + _t);
            }
        }

        internal static void PrintTableRows(string inTableNumberToken)
        {
            DbAdo _dbAdo = new DbAdo();
            List<Book> _books = _dbAdo.GetBooks();

            foreach (var item in _books)
            {
                Console.WriteLine($"Title: {item.Title}, Description: {item.Description},  Price: {item.Price}");
            }
            Console.WriteLine();
        }
    }
}
