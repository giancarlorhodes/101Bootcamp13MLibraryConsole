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
    }
}