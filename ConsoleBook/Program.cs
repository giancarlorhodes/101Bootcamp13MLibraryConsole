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

            //TODO: STEP 1 - search, login, register(DONE)  - main menu

            // loop to continue until user is done
            string input;
            bool IsFound = false;
            do
            {
                User loginInUser = new User();
                input = Printer.MainMenuPrint(IsFound);

                if (input.ToLower() == "r") // REGISTER
                {
                    // User Menu 

                    // add user
                    User u = Printer.CollectAddUserData();
                    DbAdo data = new DbAdo();
                    data.CreateUser(u);
                }
                else if(input.ToLower() == "l") // LOGIN                    
                {
                    // login method and where to go next ??

                    // WHAT ARE THE LOGICAL STEPS FOR LOGGING IN? 

                    // step 1: prompt for username and password                  
                    // step 2a: retrieve all users and put that in variable - GetUsers()
                    // step 2b: loop thru the users list, checking username/password from the list
                    // step 2c: compare username and password for current element in the loop
                    // step 2d: if match, log them in and save the info
                    // step 2f: error message, bad login and prompt to enter again

                    Console.WriteLine("Enter your username: ");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string userPassword = Console.ReadLine();

                    DbAdo data = new DbAdo();
                    List<User> listOfUsers = data.GetUsers();
                 
                    IsFound = false;

                    foreach (User current in listOfUsers)
                    {
                        if (userName == current.UserName && userPassword == current.Password)
                        {
                            // matched
                            loginInUser = current;
                            Console.WriteLine("Match found");
                            IsFound = true;
                        }                      
                    }

                    if (IsFound == false) {
                        Console.WriteLine("User incorrect. Try again.");
                    }


                    // depending on the Role, we will want to provide a custom set of menu options
                    // PATRON - least privileges
                    // CHECKOUT STUFF
                    // menu - search, update my profile, logout 
                    if (loginInUser.RoleID_FK == 3)
                    {

                        Console.WriteLine("MENU: S - Search, P - My Profile, L - Logout");

                    }
                    else if(loginInUser.RoleID_FK == 2) // LIBRARIAN ROLE
                    {

                        Console.WriteLine("MENU: S - Search, P - My Profile,  B - Book, A - Author, P - Publisher, G - Genre, L - Logout");

                    }
                    else if (loginInUser.RoleID_FK == 1) // ADMINISTRATOR ROLE
                    {
                        Console.WriteLine("MENU: S - Search, P - My Profile,  B - Book, A - Author, P - Publisher, G  - Genre, U - User, L - Logout");

                    }



                    // LIBRARIAN
                    // CHECKBACK IN STUFF
                    // menu - search, update my profile, Book, Publisher, Genre,  logout 

                    // ADMINSTRATOR - most privieges
                    // CHANGE PASSWORD, RESETTING STUFF
                    // menu - search, update my profile, Book, Publisher, Genre, Users  logout 
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
