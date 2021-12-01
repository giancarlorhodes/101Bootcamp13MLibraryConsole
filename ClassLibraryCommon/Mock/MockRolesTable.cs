using ClassLibraryCommon.DTO;
using System;
using System.Collections.Generic;


namespace ClassLibraryCommon.Mock
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
    }
}
