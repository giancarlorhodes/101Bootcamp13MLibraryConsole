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
            //DbAdo _datasource = new DbAdo(); // live database version
            MockDb _datasource = new MockDb();
            
            switch (inTableNumberToken)
            {
                case "0": // Author
                    {
                        // student finish this code
                        break;
                    }
                case "1": // Book
                    {

                        //List<Book> _books = _datasource.GetBooks();
                        List<Book> _books = _datasource.GetBooks();
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
          
        }

        internal static void HeaderPrint()
        {
            Console.WriteLine("********************* Library App Console Starting  ***********************");
        }

        internal static void ClearScreen()
        {
            Console.Clear();
        }

        public static string[] GetTokensImproved()
        {
            string[] _returnedTokens;
            Console.WriteLine("MENU: PT - print tables, P {#}, A {#} add, D {#} delete, U {#} update, C clear, Q quit. {#} is required table number argument");
            Console.WriteLine();
            var _option = Console.ReadLine().ToUpper();
            _returnedTokens = _option.Split(' ');
            return _returnedTokens;
        }


        internal static string MainMenuPrint(Boolean f)
        {
            //search, login, register  - main menu
            string input = "";
            if (!f)
            {
                Console.WriteLine("MENU: S - Search, L - Login, R - Register, Q - Quit");
                input = Console.ReadLine();
            }
            return input;
        }


        internal static User CollectAddUserData()
        {
            User u = new User();

            // code for getting this User information
            Console.WriteLine("Enter FirstName: ");
            u.FirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName: ");
            u.LastName = Console.ReadLine();
            Console.WriteLine("Enter Username: ");
            u.UserName = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            u.Password = Console.ReadLine();
            // TODO: how to deal with the RoleID ?
            u.RoleID_FK = 3; // Patron as default for now
            return u;
        }

        internal static void GeneralMenuOptions()
        {
            Console.WriteLine("MENU: S - Search, P - update my profile, L - logout");
        }
    }
}
