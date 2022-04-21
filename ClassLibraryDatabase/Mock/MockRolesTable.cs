using ClassLibraryCommon;
using ClassLibraryCommon.DTO;
using System;
using System.Collections.Generic;

namespace ClassLibraryDatabase.Mock
{

    
    internal class MockRolesTable
    {
        // data
        internal List<RoleDTO> Roles { get; set; }

        // constructors
        public MockRolesTable()
        {
            this.Roles = new List<RoleDTO>()
            {
                new RoleDTO { RoleID = (int)RoleType.Administrator, RoleName = RoleType.Administrator.ToString()},
                new RoleDTO { RoleID = (int)RoleType.Librarian, RoleName = RoleType.Librarian.ToString()},
                new RoleDTO { RoleID = (int)RoleType.Patron, RoleName = RoleType.Patron.ToString()},
                new RoleDTO { RoleID = (int)RoleType.Guest, RoleName = RoleType.Guest.ToString()}
            };
        }

        public MockRolesTable(List<RoleDTO> inDTO) 
        {
            this.Roles = inDTO;
        }


        // methods
        internal void Add(RoleDTO inRoleDTO)
        {
            this.Roles.Add(inRoleDTO);
        }

        internal void Delete(RoleDTO inRoleDTO)
        {
            this.Roles.Add(inRoleDTO);
        }

    }
}
