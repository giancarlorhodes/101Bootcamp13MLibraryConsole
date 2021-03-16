using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    internal class MockBooks
    {

        internal List<Book> Books { get; set; }

        public MockBooks() {

            Books = new List<Book>()
            { 
                new Book { Author_FK = 0, Description = "Description Book 1", Genre_FK = 0, IsPaperback = "Y", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 1" },
                new Book { Author_FK = 0, Description = "Description Book 2", Genre_FK = 0, IsPaperback = "Y", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 2" },
                new Book { Author_FK = 0, Description = "Description Book 3", Genre_FK = 0, IsPaperback = "N", Price = 12.33M, PublishDate = DateTime.Now, Publisher_FK = 0, Title = "Book 3" }
            };
        
        }

    }
}
