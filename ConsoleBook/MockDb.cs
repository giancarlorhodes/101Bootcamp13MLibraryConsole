using ConsoleLibrary.DataEntity;
using ConsoleLibrary.MockDataEntity;
using System.Collections.Generic;

namespace ConsoleLibrary
{
    internal class MockDb
    {
        internal List<Book> GetBooks()
        {
            MockBooksTable _table = new MockBooksTable();
            return _table.Books;
        }

        // TODO need GetAuthors

        // TODO need GetGenre

        // TODO need GetPublishers

        // TODO need GetRoles

        // TODO need GetUsers
    }
}