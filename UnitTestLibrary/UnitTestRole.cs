using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleLibrary.DataEntity;
using ConsoleLibrary;
using System.Linq;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestRole
    {
        // data
        private string _conn;
        private DbAdo _datasource;

        // Constructor
        public UnitTestRole()
        {
            _conn = this.GetConnectionString();
            _datasource = new DbAdo(_conn); // 
        }

        // methods
        private string GetConnectionString()
        { 
            return "Data Source=LAPTOP-401;Initial Catalog=Library;Integrated Security=True";
        }


        [TestMethod]
        public void Connect_To_DataBase_Open_Closed()
        {
            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            string o, c;

            // act
            _sqlConnection.Open();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
            o = _sqlConnection.State.ToString().ToUpper();

            _sqlConnection.Close();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
            c = _sqlConnection.State.ToString().ToUpper();

            // assert
            Assert.AreEqual(o, "OPEN");
            Assert.AreEqual(c, "CLOSED");
        }


        [TestMethod]
        public void Add_One_Role()
        {
            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            List<Role> list = new List<Role>();

            // act
            _sqlConnection.Open();
            list = _datasource.GetRole();
            int _countBeforeAdd = list.Count;

            Role r = new Role { RoleID = 0, RoleName = "Testing Role" };

            // assert
            int key = _datasource.CreateRole(r); // need to delete this one
            list = _datasource.GetRole();
            int _countAfterAdd = list.Count;
   
            Assert.IsTrue(_countBeforeAdd + 1 == _countAfterAdd);
            _datasource.DeleteRole(new Role { RoleID = key }); // cleanup
            _sqlConnection.Close();
        }


        [TestMethod]
        public void Delete_One_Role()
        {
            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            List<Role> list = new List<Role>();

            // act
            _sqlConnection.Open();
            list = _datasource.GetRole();
            int countBefore, countAfter;
            countBefore = list.Count;

            Role r = new Role { RoleID = 0, RoleName = "Testing Role" };

            // assert
            int key = _datasource.CreateRole(r); // need to delete this one          
            _datasource.DeleteRole(new Role { RoleID = key }); // 
            list = _datasource.GetRole();
            countAfter = list.Count;
            _sqlConnection.Close();
            Assert.IsTrue(countBefore == countAfter);
        }

        [TestMethod]
        public void Update_One_Role()
        {
            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            List<Role> list = new List<Role>();

            // act      
            Role addRole = new Role { RoleID = 0, RoleName = "Testing Role" };

            // assert
            int key = _datasource.CreateRole(addRole); // need to delete this one          
            //list = _datasource.GetRole();

            addRole.RoleName = "Change Role Name";
            addRole.RoleID = key;
            _datasource.UpdateRole(addRole);
      
            _datasource.DeleteRole(addRole); // clean up the added/updated row of data
            _sqlConnection.Close();

        }
    }
}
