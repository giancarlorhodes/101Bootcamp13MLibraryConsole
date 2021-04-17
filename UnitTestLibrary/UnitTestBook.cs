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
    public class UnitTestBook
    {
        // data
        private string _conn;
        private DbAdo _datasource;

        // Constructor
        public UnitTestBook()
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
        public void Add_One_Book_Count_Plus_One_And_Remove_It()
        {

            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            List<Book> list = new List<Book>();
            Book b = new Book { 
                Description = "Testing", 
                IsPaperback = true, 
                Price = 99.99M, 
                PublishDate = DateTime.Now,
                Title = "Testing",
                BookID = 0,  // auto incrementing
                GenreID_FK = 1, 
                AuthorID_FK = 1,
                PublisherID_FK = 1
            };
            int _countBeforeAdding, _countAfterAdding;

            // act
            list = _datasource.GetBooks();
            _countBeforeAdding = list.Count;
            int savePK = _datasource.CreateBook(b);  // this should add one so list will be list + 1
            list = _datasource.GetBooks();
            _countAfterAdding = list.Count;

            // assert
            Assert.AreEqual(_countBeforeAdding + 1, _countAfterAdding);

            // cleanup
            b.BookID = savePK;
            _datasource.DeleteBook(b);

        }

        [TestMethod]
        public void Add_One_Book_Update_Then_Check_For_Change_And_Remove_It()
        {

            // arrange
            SqlConnection _sqlConnection = new SqlConnection(_conn);
            List<Book> list = new List<Book>();
            Book b = new Book
            {
                Description = "Testing123",
                IsPaperback = true,
                Price = 999.99M,
                PublishDate = DateTime.Now,
                Title = "Testing123",
                BookID = 0,  // auto incrementing
                GenreID_FK = 1,
                AuthorID_FK = 1,
                PublisherID_FK = 1
            };


            // act
            int savePK = _datasource.CreateBook(b);  
            list = _datasource.GetBooks();
            Book bookToUpdate = list.Where(bk => bk.BookID == savePK).FirstOrDefault(); // this get the book
            bookToUpdate.Description = "Testing321";
            bookToUpdate.Title = "Testing321";
            _datasource.UpdateBook(bookToUpdate); // PK should already be correct because of LINQ statement
            list = _datasource.GetBooks(); // look fo this update
            Book bookUpdated = list.Where(bk => bk.Title == "Testing321").FirstOrDefault();

            // assert
            Assert.IsNotNull(bookUpdated);
            Assert.IsTrue(bookUpdated.Title == "Testing321");
            // cleanup
            b.BookID = savePK;
            _datasource.DeleteBook(b);

        }

    }
}
