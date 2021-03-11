using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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

        internal List<Book> GetBooks(int inOneParticularBook = -1) {


            // TESTing - just mock the list right now
            // MockBooks _mockBooks = new MockBooks();
            // return _mockBooks.Books;

            // implement this with ado.net  
            List<Book> _list = new List<Book>();
            string _sqlStatement = "SELECT BookID, Title, Book_Description, Book_Price, Book_IsPaperBack, Book_AuthorID_FK, GenreID_FK FROM Book";
            using (SqlConnection con = new SqlConnection(_conn))
            {
                //using (SqlCommand getUserComm = new SqlCommand("spGetBooks", con))
                using (SqlCommand _sqlCommand = new SqlCommand(_sqlStatement, con))
                {

                    //getUserComm.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandTimeout = 35;

                    _sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

                    con.Open();
                    Book _book;
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            _book = new Book
                            {
                                BookID = reader.GetInt32(reader.GetOrdinal("BookID")),
                                Title = (string)reader["Title"],
                                Description = (string)reader["Book_Description"],
                                Price = reader.GetDecimal(reader.GetOrdinal("Book_Price")),
                                IsPaperback = (string)reader["Book_IsPaperBack"],
                                Author_FK = reader.GetInt32(reader.GetOrdinal("Book_AuthorID_FK")),
                                Genre_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK"))
                            };
                            _list.Add(_book);
                        }
                    }
                    con.Close();
                }
            }
            return _list;
        }

        internal void OpenCloseConnection() 
        {

            SqlConnection _sqlConnection = new SqlConnection(_conn);
            _sqlConnection.Open();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
            _sqlConnection.Close();
            Console.WriteLine("Connection is " + _sqlConnection.State.ToString());

        }


    }
}
