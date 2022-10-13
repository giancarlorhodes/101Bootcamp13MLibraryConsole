using System;
using System.Collections.Generic;
using System.Configuration;
using CLCommonCore.DTO;
using CLCommonCore;
using CLDatabaseCore;

namespace LibraryUICore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // loop to continue until user is done - key q
            string _input = "";
            UserDTO user = new UserDTO();
            //bool IsFound = false;
            MockDb db = new MockDb();
            string _connection = ConfigurationManager.ConnectionStrings["DBCONN"].ToString();
            string _database = ConfigurationManager.AppSettings["MOCKORDB"].ToString(); // either Mock Db or real Db
            DbAdo ado = new DbAdo(_connection);

            Printer.MainMenu();
            _input = Console.ReadLine().ToLower();

            do
            {
                // enter app as a guest                  
                if (_input.ToLower() == "g")
                {
                    user = new UserDTO(RoleType.Guest);
                }

                if (_input.ToLower() == "pp")
                {
                    Printer.Profile(user);
                }



                if (_input.ToLower() == "pu")
                {

                    List<UserDTO> _users = new List<UserDTO>(); ;
                    if (_database == DBType.Mock.ToString())
                    {
                        _users = db.GetUsers();
                    }
                    else
                    {
                        // database version
                        _users = ado.GetUsers();

                    }
                    Printer.Users(_users); // TODO: implement this     

                }


                if (_input.ToLower() == "pr")
                {
                    // TODO: can I make the configurable??
                    List<RoleDTO> _roles;

                    if (_database == DBType.Mock.ToString())
                    {
                        _roles = db.GetRoles();
                    }
                    else
                    {
                        _roles = ado.GetRoles();

                    }
                    Printer.Roles(_roles); // TODO: implement this               
                }

                if (_input.ToLower() == "pm")
                {
                    Printer.MainMenu();
                }

                if (_input.ToLower() == "r") // REGISTER
                {


                    UserDTO u = Printer.CollectAddUserData();
                    if (_database == DBType.Mock.ToString())
                    {
                        db.CreateUser(u);
                    }
                    else
                    {
                        // database version
                        ado.CreateUser(u);

                    }
                }

                Printer.MainMenu();
                _input = Console.ReadLine().ToLower();

            } while (_input.ToLower() != "q");

            Printer.End();
            Console.ReadLine(); // stop program
        }
    }
}
