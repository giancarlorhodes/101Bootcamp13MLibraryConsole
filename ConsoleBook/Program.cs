using ClassLibraryCommon;
using ClassLibraryCommon.DTO;
using ClassLibraryDatabase;
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

         
            //Printer.HeaderPrint();

            // loop to continue until user is done - key q
            string _input="";
            UserDTO user = new UserDTO();
            //bool IsFound = false;
            MockDb db = new MockDb();
            Printer.MainMenu();

            do
            {
                                  
                _input = Console.ReadLine().ToLower();


                if (_input.ToLower() == "g") 
                {
                    user = new UserDTO(RoleType.Guest);                
                }


                if (_input.ToLower() == "pp")
                {
                    Printer.Profile(user);
                }


                if (_input.ToLower() == "pr") 
                {
                    var _roles = db.GetRoles();
                    Printer.Roles(_roles); // TODO: implement this               
                }

                if (_input.ToLower() == "pm")
                {

                    Printer.MainMenu();

                }

                //    if (input.ToLower() == "r") // REGISTER
                //    {

                //        // add user
                //        User u = Printer.CollectAddUserData();
                //        DbAdo data = new DbAdo();
                //        data.CreateUser(u);
                //    }
                //    else if(input.ToLower() == "l") // LOGIN                    
                //    {
                //        // login method and , where to go next ??

                //        // WHAT ARE THE LOGICAL STEPS FOR LOGGING IN? 

                //        // step 1: prompt for username and password                  
                //        // step 2a: retrieve all users and put that in variable - GetUsers()
                //        // step 2b: loop thru the users list, checking username/password from the list
                //        // step 2c: compare username and password for current element in the loop
                //        // step 2d: if match, log them in and save the info
                //        // step 2f: error message, bad login and prompt to enter again

                //        Console.WriteLine("Enter your username: ");
                //        string userName = Console.ReadLine();
                //        Console.WriteLine("Enter your password: ");
                //        string userPassword = Console.ReadLine();

                //        DbAdo data = new DbAdo();
                //        //List<User> listOfUsers = data.GetUsers();

                //        IsFound = false;

                //        foreach (User current in listOfUsers)
                //        {
                //            if (userName == current.UserName && userPassword == current.Password)
                //            {
                //                // matched
                //                loginInUser = current;
                //                Console.WriteLine("Match found. Welcome {0} {1}. Your Role is {2}.", loginInUser.FirstName, 
                //                    loginInUser.LastName, loginInUser.Role.RoleName);
                //                IsFound = true;
                //            }                      
                //        }

                //        if (IsFound == false) {
                //            Console.WriteLine("User incorrect. Try again.");
                //        }

                //        // depending on the Role, we will want to provide a custom set of menu options
                //        // PATRON - least privileges
                //        // CHECKOUT STUFF
                //        // menu - search, update my profile, logout 
                //        if (loginInUser.RoleID_FK == (int)Roles.Patron) // PATRON ROLE
                //        {
                //            Console.WriteLine("MENU: S - Search, P - My Profile, O - Logout");
                //            string inputPatron = Console.ReadLine();
                //            if (inputPatron.ToLower() == "o")
                //            {
                //                IsFound = false; // without this - a bug that caused an infinite loop
                //                Console.WriteLine("Logging out .... Bye {0} {1}", loginInUser.FirstName, loginInUser.LastName);
                //                continue;
                //            }
                //            else
                //            {
                //                Printer.PatronOptions(inputPatron, loginInUser);
                //            }
                //        }
                //        else if(loginInUser.RoleID_FK == (int)Roles.Librarian) // LIBRARIAN ROLE
                //        {

                //            Console.WriteLine("MENU: S - Search, P - My Profile,  B - Book, A - Author, " + 
                //                " P - Publisher, G - Genre, O - Logout");
                //            string inputLibrarian = Console.ReadLine();
                //            if (inputLibrarian.ToLower() == "o")
                //            {
                //                IsFound = false; // without this - a bug that caused an infinite loop
                //                Console.WriteLine("Logging out .... Bye {0} {1}", loginInUser.FirstName, loginInUser.LastName);
                //                continue;
                //            }
                //            else
                //            {
                //                Printer.LibrarianOptions(inputLibrarian, loginInUser);
                //            }
                //        }
                //        else if (loginInUser.RoleID_FK == (int)Roles.Administrator) // ADMINISTRATOR ROLE
                //        {
                //            Console.WriteLine("MENU: S - Search, P - My Profile,  B - Book, A - Author, " + 
                //                " P - Publisher, G - Genre, U - User, O - Logout");
                //            string inputAdmin = Console.ReadLine();
                //            if (inputAdmin.ToLower() == "o")
                //            {
                //                IsFound = false; // without this - a bug that caused an infinite loop
                //                Console.WriteLine("Logging out .... Bye {0} {1}", loginInUser.FirstName, loginInUser.LastName);
                //                continue;
                //            }
                //            else 
                //            {
                //                Printer.AdminOptions(inputAdmin, loginInUser);
                //            }
                //        }

                //        // ADMINSTRATOR - most privieges
                //        // CHANGE PASSWORD, RESETTING STUFF
                //        // menu - search, update my profile, Book, Publisher, Genre, Users  logout 
                //    }
            } while (_input.ToLower() != "q");

                Printer.End();
                Console.ReadLine(); // stop program
        }
    }
}





//********************************* OLD CODE *****************************************************************/


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
