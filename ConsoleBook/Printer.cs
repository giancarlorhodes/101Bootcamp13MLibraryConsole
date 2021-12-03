using ClassLibraryCommon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    internal static class Printer
    {


        internal static void MainMenu()
        {
          
            Console.WriteLine("MENU: g - guest,  r- register, l - login, o - logout, pp - print profile, " +
                "pr - print roles, pu - print users, q - quit program");
            
        }


        internal static void End()
        {
            Console.WriteLine("Library App Console Ending. Press Enter ....");

        }

        internal static void Profile(UserDTO user)
        {
            Console.WriteLine("first name: {0}, last name: {1}, user: {2}", user.FirstName, user.LastName, user.UserName);
        }

        internal static void Roles(List<RoleDTO> roles)
        {
            throw new NotImplementedException();
        }
    }
    //    // DATA
    //    private List<TableName> Tables { get; }

    //    // CONSTRUCTORS
    //    public Printer(List<TableName> inTables)
    //    {
    //        Tables = inTables;
    //    }

    //    // METHODS    
    //    internal void PrintTables()
    //    {
    //        Console.WriteLine("****************  TABLES ***********************");
    //        foreach (var _t in Tables)
    //        {
    //            Console.WriteLine("Table number: " + (int)_t + ", Table name: " + _t);
    //        }
    //    }



    //    /// <summary>
    //    ///  prints out the details for the table or list
    //    /// </summary>
    //    /// <param name="inTableNumberToken"></param>
    //    internal static void PrintTableRows(string inTableNumberToken)
    //    {
    //        //DbAdo _datasource = new DbAdo(); // live database version
    //        MockDb _datasource = new MockDb();

    //        switch (inTableNumberToken)
    //        {
    //            case "0": // Author
    //                {
    //                    // student finish this code
    //                    break;
    //                }
    //            case "1": // Book
    //                {

    //                    //List<Book> _books = _datasource.GetBooks();
    //                    List<Book> _books = _datasource.GetBooks();
    //                    foreach (var item in _books)
    //                    {
    //                        Console.WriteLine($"Title: {item.Title}, Description: {item.Description},  Price: {item.Price}");
    //                    }
    //                    break;
    //                }
    //        }

    //        Console.WriteLine();

    //    }

    //    internal static void FooterPrint()
    //    {
    //        Console.WriteLine("********************* Library App Console Ending  ***********************");

    //    }

    //    internal static void HeaderPrint()
    //    {
    //        Console.WriteLine("********************* Library App Console Starting  ***********************");
    //    }

    //    internal static void ClearScreen()
    //    {
    //        Console.Clear();
    //    }

    //    public static string[] GetTokensImproved()
    //    {
    //        string[] _returnedTokens;
    //        Console.WriteLine("MENU: PT - print tables, P {#}, A {#} add, D {#} delete, U {#} update, " + 
    //            " C clear, Q quit. {#} is required table number argument");
    //        Console.WriteLine();
    //        var _option = Console.ReadLine().ToUpper();
    //        _returnedTokens = _option.Split(' ');
    //        return _returnedTokens;
    //    }


    //    internal static void MainMenuPrint(Boolean print)
    //    {
    //        if (!print)
    //        {
    //            Console.WriteLine("MENU: S - Search, L - Login, R - Register, Q - Quit");
    //        }      
    //    }


    //    internal static User CollectAddUserData()
    //    {
    //        User u = new User();

    //        // code for getting this User information
    //        Console.WriteLine("Enter FirstName: ");
    //        u.FirstName = Console.ReadLine();
    //        Console.WriteLine("Enter LastName: ");
    //        u.LastName = Console.ReadLine();
    //        Console.WriteLine("Enter Username: ");
    //        u.UserName = Console.ReadLine();
    //        Console.WriteLine("Enter Password: ");
    //        u.Password = Console.ReadLine();
    //        // TODO: how to deal with the RoleID ?
    //        u.RoleID_FK = 3; // Patron as default for now
    //        return u;
    //    }

    //    internal static void PatronOptions(string inInputPatron, User loginInUser)
    //    {


    //        DbAdo data = new DbAdo();
    //        List<User> listOfUsers;


    //        switch (inInputPatron)
    //        {
    //            case "p": 
    //            {
    //                    User userUpdate = loginInUser;        
    //                    Console.WriteLine("Update user profile ...");

    //                    Console.Write("FirstName: {0}: ", loginInUser.FirstName);
    //                    string inputFName = Console.ReadLine();                        
    //                    userUpdate.FirstName = inputFName;
    //                    Console.WriteLine();

    //                    Console.Write("LastName: {0}: ", loginInUser.LastName);
    //                    string inputLName = Console.ReadLine();
    //                    userUpdate.LastName = inputLName;
    //                    Console.WriteLine();

    //                    Console.Write("Username: {0}: ", loginInUser.UserName);
    //                    string inputUsername = Console.ReadLine();
    //                    userUpdate.UserName = inputUsername;
    //                    Console.WriteLine();

    //                    Console.Write("Password: {0}: ", loginInUser.Password);
    //                    string inputPassword = Console.ReadLine();
    //                    userUpdate.Password = inputPassword;

    //                    data.UpdateUser(userUpdate);
    //                    Console.WriteLine("Updating profile ...");

    //                    listOfUsers = data.GetUsers();
    //                    foreach (var user in listOfUsers)
    //                    {
    //                        Console.WriteLine("FirstName: {0}, LastName: {1}, Username: {2}, Password: {3}",
    //                            user.FirstName, user.LastName, user.UserName, user.Password);
    //                    }

    //                    break; 
    //            }
    //            case "s": {

    //                break;
    //            }
    //            default:
    //                break;
    //        }

    //    }

    //    internal static void GeneralMenuOptions()
    //    {
    //        Console.WriteLine("MENU: S - Search, P - update my profile, L - logout");
    //    }

    //    internal static void LibrarianOptions(string inInputLibrarian, User loginInUser)
    //    {

    //        DbAdo data = new DbAdo();
    //        switch (inInputLibrarian)
    //        {
    //            case "p":
    //                {
    //                    User userUpdate = loginInUser;
    //                    Console.WriteLine("Updating profile ...");
    //                    Console.Write("FirstName: {0}: ", loginInUser.FirstName);
    //                    string inputFName = Console.ReadLine();
    //                    userUpdate.FirstName = inputFName;
    //                    Console.Write("LastName: {0}: ", loginInUser.LastName);
    //                    string inputLName = Console.ReadLine();
    //                    userUpdate.LastName = inputLName;
    //                    //TODO: data.updateUser(userUpdate);
    //                    break;
    //                }
    //            case "b":
    //                {

    //                    Console.WriteLine("Printing current booklist ...");                        
    //                    List<Book> list = data.GetBooks();

    //                    Console.WriteLine("BookID\t\tPrice\t\tTitle\t");
    //                    foreach (var b in list)
    //                    {
    //                        Console.WriteLine(b.BookID + "\t\t" +b.Price + "\t\t" + b.Title + "\t");                                 
    //                    }

    //                    Console.WriteLine("MENU BOOK: AB - add book, UB - update book,  DB - delete book");
    //                    string bookOperation = Console.ReadLine();
    //                    if (bookOperation == "AB")
    //                    {

    //                    }
    //                    else if (bookOperation == "UB")
    //                    {

    //                    }
    //                    else if (bookOperation == "DB")
    //                    { 

    //                    }
    //                    break;
    //                }

    //            case "s":
    //                {

    //                    break;
    //                }
    //            default:
    //                break;
    //        }
    //    }

    //    internal static void AdminOptions(string inInputAdmin, User loginInUser)
    //    {
    //        DbAdo data = new DbAdo();
    //        switch (inInputAdmin)
    //        {
    //            case "p":
    //                {
    //                    User userUpdate = loginInUser;
    //                    Console.WriteLine("Updating profile ...");
    //                    Console.Write("FirstName: {0}: ", loginInUser.FirstName);
    //                    string inputFName = Console.ReadLine();
    //                    userUpdate.FirstName = inputFName;
    //                    Console.Write("LastName: {0}: ", loginInUser.LastName);
    //                    string inputLName = Console.ReadLine();
    //                    userUpdate.LastName = inputLName;
    //                    //TODO: data.updateUser(userUpdate);
    //                    break;
    //                }
    //            case "b":
    //                {

    //                    Console.WriteLine("Printing current booklist ...");
    //                    List<Book> list = data.GetBooks();

    //                    Console.WriteLine("BookID\t\tPrice\t\tTitle\t");
    //                    foreach (var b in list)
    //                    {
    //                        Console.WriteLine(b.BookID + "\t\t" + b.Price + "\t\t" + b.Title + "\t");
    //                    }

    //                    Console.WriteLine("MENU BOOK: AB - add book, UB - update book,  DB - delete book");
    //                    string bookOperation = Console.ReadLine();
    //                    if (bookOperation == "AB")
    //                    {

    //                    }
    //                    else if (bookOperation == "UB")
    //                    {

    //                    }
    //                    else if (bookOperation == "DB")
    //                    {

    //                    }
    //                    break;
    //                }

    //            case "s":
    //                {

    //                    break;
    //                }
    //            default:
    //                break;
    //        }
    //    }
    //}
}
