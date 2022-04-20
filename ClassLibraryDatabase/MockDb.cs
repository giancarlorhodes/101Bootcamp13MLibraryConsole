using System.Collections.Generic;
using ClassLibraryCommon.DTO;
using ClassLibraryDatabase.Mock;

namespace ClassLibraryDatabase
{
    public class MockDb 
    {

        //    internal List<Book> GetBooks()
        //    {
        //        MockBooksTable _table = new MockBooksTable();
        //        return _table.Books;
        //    }

        // TODO need GetAuthors

        // TODO need GetGenre

        // TODO need GetPublishers


        // TODO need GetUsers
        #region Users
        // R-Read part of CRUD
        public List<UserDTO> GetUsers()
        {
            MockUsersTable _table = new MockUsersTable();
            return _table.GetUsers();
        }

        #endregion

        #region Roles
        // R part of CRUD
        public List<RoleDTO> GetRoles()
        {
            MockRolesTable _table = new MockRolesTable();
            return _table.Roles;
        }


        // C part of CRUD
        internal void AddRole(RoleDTO inRoleDTO)
        {
            // implementation
            MockRolesTable _table = new MockRolesTable();
            _table.Add(inRoleDTO);
        }


        // U part of CRUD
        internal void UpdateRole(RoleDTO inRoleDTO)
        {
            // implementation

        }

        // D part of CRUD
        internal void DeleteRole(RoleDTO inRoleDTO)
        {
            // implementation

        }

        #endregion


       
    }
}