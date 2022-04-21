using System.Collections.Generic;
using ClassLibraryCommon.DTO;
using System;

namespace ClassLibraryCommon.Mock
{


    internal class MockBooksTable
    {
        // data
        private List<BookDTO> _books;
        private const int _numberOfBooksToGenerate = 10000;

        // constructors
        public MockBooksTable()
        {

            this._books = new List<BookDTO>()
            {
                new BookDTO { BookID = 1, AuthorID_FK = 0, Description = "Description Book 1", GenreID_FK = 0, IsPaperback = true, Price = 12.33M, PublishDate = DateTime.Now, PublisherID_FK = 0, Title = "Book 1" },
                new BookDTO { BookID = 2, AuthorID_FK = 0, Description = "Description Book 2", GenreID_FK = 0, IsPaperback = true, Price = 12.33M, PublishDate = DateTime.Now, PublisherID_FK = 0, Title = "Book 2" },
                new BookDTO { BookID = 3, AuthorID_FK = 0, Description = "Description Book 3", GenreID_FK = 0, IsPaperback = true, Price = 12.33M, PublishDate = DateTime.Now, PublisherID_FK = 0, Title = "Book 3" }
            };

            BookDTO newBook = new BookDTO 
            { 
                AuthorID_FK = 0, 
                Description = "Description Book 4", 
                GenreID_FK = 0, 
                IsPaperback = true, 
                Price = 12.33M, 
                PublishDate = DateTime.Now, 
                PublisherID_FK = 0, Title = "Book 4" 
            };

            this._books.Add(newBook);

            List<BookDTO> newBooks = GenerateBooks(_numberOfBooksToGenerate);

            // TODO: combine two lists
        }

        public List<BookDTO> GenerateBooks(int numberOfBooksToGenerate)
        {
          
            List<BookDTO> books = new List<BookDTO>();  

            for (int i = 0; i < numberOfBooksToGenerate; i++)
            {
                BookDTO newBook = new BookDTO
                {
                    AuthorID_FK = 0,
                    Description = Guid.NewGuid().ToString(),
                    GenreID_FK = 0,
                    IsPaperback = true,
                    Price = GeneratePrice(),
                    PublishDate = DateTime.Now,
                    PublisherID_FK = 0,
                    Title = Guid.NewGuid().ToString()
                };

                books.Add(newBook);
            };
            return books;
        }

        private decimal GeneratePrice()
        {
            Random rnd = new Random();
            int decimal_places = 2;
            return Math.Round(new decimal(rnd.NextDouble()), decimal_places);
        }
    }
}
