
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCommon.DTO
{
    public class UserDTO
    {
        // data 
        public int UserID { get; set; } // primary key property
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID_FK { get; set; } // foreign key property

        public RoleDTO Role { get; set; }

        // constructor
        public UserDTO() 
        {
            Role = new RoleDTO();
        }

        public UserDTO(RoleType inRoleType)
        {

            switch (inRoleType)
            {
                case RoleType.Guest:
                    this.FirstName = "Guest";
                    this.LastName = "Guest";
                    break;
                case RoleType.Administrator:
                    break;
                case RoleType.Librarian:
                    break;
                case RoleType.Patron:
                    break;
                default:
                    break;
            }

        }
    }
}
