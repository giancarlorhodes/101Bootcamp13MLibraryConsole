using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleLibrary;
using System.Linq;
using ClassLibraryDatabase;
using ClassLibraryCommon.DTO;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestDbAdo
    {
        // data
        private string _conn;
        private DbAdo _dbado;

        // Constructor
        public UnitTestDbAdo()
        {
            _conn = this.GetConnectionString();
            _dbado = new DbAdo(_conn); // 
        }

        // methods
        private string GetConnectionString()
        {
            return "Data Source=LAPTOP-1RTOL5OV;Initial Catalog=LibraryUT;Integrated Security=True";
            //return  ConfigurationManager.AppSettings["DBCONN"].ToString();
        }

        [TestMethod]
        public void Add_Exception_To_Logging_Table()
        {

            // arrange
            Exception _exception = new Exception("message");
            //_exception.StackTrace = "stacktrace"; // only get - will be null
            _exception.Source = "Add_Exception_To_Logging_Table()";

            // act
            int _pk = _dbado.LogException(_exception);

          
            // assert          
            Assert.IsTrue(_pk > 0);

        }

        [TestMethod]
        public void Add_One_Role()
        {

            // arrange


            //        SqlConnection _sqlConnection = new SqlConnection(_conn);
            //        List<Book> list = new List<Book>();
            RoleDTO roleDTO = new RoleDTO
            {
                RoleName = "TESTROLE",
                Comment = "Comment",
                ModifiedByUserId = 0, // SYSTEM USER ID
                DateModified = DateTime.Now
            };


            // act

            int _pk = _dbado.CreateRole(roleDTO);
            //        int savePK = _datasource.CreateBook(b);  
            //        list = _datasource.GetBooks();
            //        Book bookToUpdate = list.Where(bk => bk.BookID == savePK).FirstOrDefault(); // this get the book
            //        bookToUpdate.Description = "Testing321";
            //        bookToUpdate.Title = "Testing321";
            //        _datasource.UpdateBook(bookToUpdate); // PK should already be correct because of LINQ statement
            //        list = _datasource.GetBooks(); // look fo this update
            //        Book bookUpdated = list.Where(bk => bk.Title == "Testing321").FirstOrDefault();

            // assert
            Assert.IsTrue(_pk > 0);

            //        Assert.IsNotNull(bookUpdated);
            //        Assert.IsTrue(bookUpdated.Title == "Testing321");

            //        // cleanup
            //        b.BookID = savePK;
            //        _datasource.DeleteBook(b);

            //    
        }


        [TestMethod]
        public void Read_Roles_Table_Should_Return_Rows_Greater_Than_Zero() 
        {

            // arrange


            // act
            var _rows = _dbado.GetRoles();


            // assert
            Assert.IsTrue(_rows.Count > 0);
        }


        [TestMethod]
        public void Delete_The_Max_PK_From_Roles_Table()
        {

            // arrange

            // act
            var _rows = _dbado.GetRoles();
            int _count = _rows.Count;
            int _max = _rows.Max(y => y.RoleID);
            _dbado.DeleteRole(new RoleDTO { RoleID = _max });
            _rows = _dbado.GetRoles();
            int _count_after_delete = _rows.Count;

            // assert
            Assert.IsTrue(_count == _count_after_delete + 1);
        }


    }
}
