using System;
using System.Collections.Generic;
using ConsoleLibrary.DataEntity;

namespace ConsoleLibrary.MockDataEntity
{
    internal class MockBooksTable
    {
        // data
        internal List<Book> Books { get; set; }


        // constructors
        public MockBooksTable() {

            this.Books = new List<Book>()
            { 
                new Book { BookID = 1, Author_FK = 0, Description = "Description Book 1", Genre_FK = 0, IsPaperback = "Y", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 1" },
                new Book {  Author_FK = 0, Description = "Description Book 2", Genre_FK = 0, IsPaperback = "Y", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 2" },
                new Book { Author_FK = 0, Description = "Description Book 3", Genre_FK = 0, IsPaperback = "N", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 3" }
            };
            Book newBook = new Book { Author_FK = 0, Description = "Description Book 4", Genre_FK = 0, IsPaperback = "Y", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 4" };
            newBook.Description = "Description Book 4+";
            this.Books.Add(newBook);
        }

    }
}
