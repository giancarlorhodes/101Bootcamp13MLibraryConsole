using CLCommonCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUICore
{
    
    public  class Printer 
    {
        internal static void MainMenu()
        {

            Console.WriteLine("MENU: select option and hit Enter");
            Console.WriteLine("g - use app as guest,  r- register, l - login, o - logout");
            Console.WriteLine("ar - add role, dr - delete role, ur - update role");
            Console.WriteLine("pr - print roles, pu - print users,  pm - print menu, q - quit program");
            Console.WriteLine();
        }


        public static string End()
        {
            var _output = "Library App Console Ending. Press Enter ....";
            Console.WriteLine(_output);
            return _output;
        }

        internal static void Profile(UserDTO user)
        {
            Console.WriteLine("first name: {0}, last name: {1}, user: {2}", user.FirstName, user.LastName, user.UserName);
            Console.WriteLine();
        }

        internal static void Roles(List<RoleDTO> roles)
        {
            Console.WriteLine("Role name\t\tComment");
            foreach (var item in roles)
            {
                Console.WriteLine(item.RoleName + "\t\t" + item.Comment);
            }
            Console.WriteLine();
        }

        internal static void Users(List<UserDTO> users)
        {
            Console.WriteLine("Firstname\t\t\tLastname");
            foreach (var item in users)
            {
                Console.WriteLine(item.FirstName + "\t\t\t" + item.LastName);
            }
            Console.WriteLine();
        }

        internal static UserDTO CollectAddUserData()
        {
            UserDTO u = new UserDTO();

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
            Console.WriteLine();
            return u;
        }
    }
}
