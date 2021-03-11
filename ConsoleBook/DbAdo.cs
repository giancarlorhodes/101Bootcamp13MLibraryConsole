using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleLibrary
{
    internal class DbAdo
    {

        private string _conn;

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        }

        public DbAdo() {

            _conn = this.GetConnectionString();
        }

        internal List<Book> GetBooks(int _oneParticularBook = -1) {

           
            // TESTing - just mock the list right now
            MockBooks _mockBooks = new MockBooks();
            return _mockBooks.Books;

            // implement this with ado.net

        }

    }
}
