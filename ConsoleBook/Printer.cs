using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Printer
    {

        public List<string> Tables { get; }

        public Printer(List<string> ts)
        {
            Tables = ts;
        }

        internal void PrintTables()
        {
            Console.WriteLine("****************  TABLES ***********************");
            foreach (var _t in Tables)
            {
                Console.WriteLine(_t);
            }
        }
    }
}
