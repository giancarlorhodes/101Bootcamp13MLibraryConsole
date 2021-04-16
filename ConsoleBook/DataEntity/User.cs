using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class User
    {
        // data 
        public int UserID { get; set; } // primary key property
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID_FK { get; set; } // foreign key property
    }
}
