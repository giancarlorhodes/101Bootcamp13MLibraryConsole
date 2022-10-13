using System.Collections.Generic;
using CLCommonCore.DTO;
using CLDatabaseCore.Mock;

namespace CLDatabaseCore
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

        private MockUsersTable _tableUsers;
        private MockRolesTable _tableRoles;
        private MockBooksTable _tableBooks;

        public MockDb() 
        { 
            _tableUsers = new MockUsersTable();
            _tableRoles = new MockRolesTable();
            _tableBooks = new MockBooksTable();
        
        }


        #region Users
        // R-Read part of CRUD
        public List<UserDTO> GetUsers()
        {          
            return _tableUsers.GetUsers();
        }


        public void CreateUser(UserDTO u)
        {
            _tableUsers.Add(u);

        }

        public void DeleteUser(UserDTO u)
        {
            _tableUsers.Delete(u);
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