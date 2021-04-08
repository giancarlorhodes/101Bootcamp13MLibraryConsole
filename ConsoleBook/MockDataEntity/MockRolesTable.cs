using ConsoleLibrary.DataEntity;
using System;
using System.Collections.Generic;


namespace ConsoleLibrary.MockDataEntity
{
    internal class MockRolesTable
    {
        // data
        internal List<Role> Roles { get; set; }

        // constructors
        public MockRolesTable()
        {
            this.Roles = new List<Role>()
            {
                new Role { RoleID = 1, RoleName = "Administrator"},
                new Role { RoleID = 2, RoleName = "Librarian"},
                new Role { RoleID = 3, RoleName = "Patron"},
            };
        }
    }
}
