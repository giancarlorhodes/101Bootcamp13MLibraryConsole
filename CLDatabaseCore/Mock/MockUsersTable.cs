using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLCommonCore.DTO;

namespace CLDatabaseCore.Mock
{
    internal class MockUsersTable
    {

        internal List<UserDTO> Users { get; set; }


        public MockUsersTable()
        {

            Users = new List<UserDTO>()
            {
                new UserDTO(){ FirstName = "Giancarlo", LastName = "Rhodes"},
                new UserDTO(){ FirstName = "Taylor", LastName = "Gross"}
            };

        }

        public MockUsersTable(List<UserDTO> users)
        { 
            Users = users;
        
        }

        // CRUD  -  create ... insert
        internal void Add(UserDTO u)
        {
            Users.Add(u);
        }

        // delete SQL
        internal void Delete(UserDTO u)
        {
            Users.Remove(u);
        }

        // TODO: Edit   Update ... SQL


        // read  ... SELECT
        internal List<UserDTO> GetUsers()
        {
            return Users;
        }


    }
}
