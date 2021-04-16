using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ConsoleLibrary.DataEntity;

namespace ConsoleLibrary
{
    public class DbAdo
    {
         // data
         private string _conn;

        // Constructor
        public DbAdo()
        {
            _conn = this.GetConnectionString();
        }

        public DbAdo(string conn)
        {
            _conn = conn;
        }

        // methods
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        }

        // ROLES CRUD
        public List<Role> GetRole() 
        {
            List<Role> _list = new List<Role>();

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spGetRole", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    //_sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

                    con.Open();
                    Role _role;
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _role = new Role
                            {
                                 RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                 RoleName = (string)reader["RoleName"]
                                //Description = (string)reader["Book_Description"],
                                //Price = reader.GetDecimal(reader.GetOrdinal("Book_Price")),
                                //IsPaperback = (string)reader["Book_IsPaperBack"],
                                //Author_FK = reader.GetInt32(reader.GetOrdinal("Book_AuthorID_FK")),
                                //Genre_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK"))
                            };
                            _list.Add(_role);
                        }
                    }
                    con.Close();
                }
            }
            return _list;
        }

        public int CreateRole(Role r)
        {

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateRole", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    //_sqlCommand.Parameters.AddWithValue("@ParamRoleName", r.RoleName);
                    //_sqlCommand.Parameters.Add("@ParamRoleName", SqlDbType.NVarChar(100)).Value = r.RoleName;
                    SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
                    _paramRoleName.DbType = DbType.String;
                    _paramRoleName.ParameterName = "@ParamRoleName";
                    _paramRoleName.Value = r.RoleName;
                    _sqlCommand.Parameters.Add(_paramRoleName);

                    SqlParameter _paramRoleIDReturn = _sqlCommand.CreateParameter();
                    _paramRoleIDReturn.DbType = DbType.Int32;
                    _paramRoleIDReturn.ParameterName = "@ParamOutRoleID";                   
                    var pk = _sqlCommand.Parameters.Add(_paramRoleIDReturn);
                    _paramRoleIDReturn.Direction = ParameterDirection.Output;

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp 
                    var result = _paramRoleIDReturn.Value;
                    con.Close();
                    return (int)result;
                }
            }
        }

        public void DeleteRole(Role r) 
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spDeleteRole", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    SqlParameter _parameter = _sqlCommand.CreateParameter();
                    _parameter.DbType = DbType.Int32;
                    _parameter.ParameterName = "@ParamRoleID";
                    _parameter.Value = r.RoleID;
                    _sqlCommand.Parameters.Add(_parameter);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                    con.Close();
                }
            }
        }

        public void UpdateRole(Role r)
        {
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spUpdateRole", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
                    _paramRoleName.DbType = DbType.String;
                    _paramRoleName.ParameterName = "@ParamRoleName";
                    _paramRoleName.Value = r.RoleName;
                    _sqlCommand.Parameters.Add(_paramRoleName);

                    SqlParameter _paramRoleID = _sqlCommand.CreateParameter();
                    _paramRoleID.DbType = DbType.Int32;
                    _paramRoleID.ParameterName = "@ParamRoleID";
                    _paramRoleID.Value = r.RoleID;
                    _sqlCommand.Parameters.Add(_paramRoleID);

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                    con.Close();
                }
            }
        }


        public void CreateUser(User u)
        {

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateUser", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = u.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);

                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = u.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);

                    SqlParameter _paramUserName = _sqlCommand.CreateParameter();
                    _paramUserName.DbType = DbType.String;
                    _paramUserName.ParameterName = "@ParamUserName";
                    _paramUserName.Value = u.UserName;
                    _sqlCommand.Parameters.Add(_paramUserName);

                    SqlParameter _paramPassword = _sqlCommand.CreateParameter();
                    _paramPassword.DbType = DbType.String;
                    _paramPassword.ParameterName = "@ParamPassword";
                    _paramPassword.Value = u.Password;
                    _sqlCommand.Parameters.Add(_paramPassword);

                    SqlParameter _paramRoleIdFK = _sqlCommand.CreateParameter();
                    _paramRoleIdFK.DbType = DbType.Int32;
                    _paramRoleIdFK.ParameterName = "@ParamRoleID";
                    _paramRoleIdFK.Value = u.RoleID_FK;
                    _sqlCommand.Parameters.Add(_paramRoleIdFK);

                    //SqlParameter _paramAuthorIDReturn = _sqlCommand.CreateParameter();
                    //_paramAuthorIDReturn.DbType = DbType.Int32;
                    //_paramAuthorIDReturn.ParameterName = "@ParamOutAuthorID";
                    //var pk = _sqlCommand.Parameters.Add(_paramAuthorIDReturn);
                    //_paramAuthorIDReturn.Direction = ParameterDirection.Output;

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp 
                                                     //var result = _paramAuthorIDReturn.Value;
                    con.Close();
                    //return (int)result;


                }
            }
        }


        public void CreateAuthor(Author a)

        {

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("spCreateAuthor", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;
                    //_sqlCommand.Parameters.AddWithValue("@ParamRoleName", r.RoleName);
                    //_sqlCommand.Parameters.Add("@ParamRoleName", SqlDbType.NVarChar(100)).Value = r.RoleName;
                    SqlParameter _paramFirstName = _sqlCommand.CreateParameter();
                    _paramFirstName.DbType = DbType.String;
                    _paramFirstName.ParameterName = "@ParamFirstName";
                    _paramFirstName.Value = a.FirstName;
                    _sqlCommand.Parameters.Add(_paramFirstName);

                    SqlParameter _paramLastName = _sqlCommand.CreateParameter();
                    _paramLastName.DbType = DbType.String;
                    _paramLastName.ParameterName = "@ParamLastName";
                    _paramLastName.Value = a.LastName;
                    _sqlCommand.Parameters.Add(_paramLastName);

                    SqlParameter _paramBio = _sqlCommand.CreateParameter();
                    _paramBio.DbType = DbType.String;
                    _paramBio.ParameterName = "@ParamBio";
                    _paramBio.Value = a.Bio;
                    _sqlCommand.Parameters.Add(_paramBio);

                    SqlParameter _paramDateOfBirth = _sqlCommand.CreateParameter();
                    _paramDateOfBirth.DbType = DbType.DateTime;
                    _paramDateOfBirth.ParameterName = "@ParamDateOfBirth";
                    _paramDateOfBirth.Value = a.DateOfBirth;
                    _sqlCommand.Parameters.Add(_paramDateOfBirth);

                    SqlParameter _paramBirthLocation = _sqlCommand.CreateParameter();
                    _paramBirthLocation.DbType = DbType.String;
                    _paramBirthLocation.ParameterName = "@ParamBirthLocation";
                    _paramBirthLocation.Value = a.BirthLocation;
                    _sqlCommand.Parameters.Add(_paramBirthLocation);


                    //SqlParameter _paramAuthorIDReturn = _sqlCommand.CreateParameter();
                    //_paramAuthorIDReturn.DbType = DbType.Int32;
                    //_paramAuthorIDReturn.ParameterName = "@ParamOutAuthorID";
                    //var pk = _sqlCommand.Parameters.Add(_paramAuthorIDReturn);
                    //_paramAuthorIDReturn.Direction = ParameterDirection.Output;

                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp 
                                                     //var result = _paramAuthorIDReturn.Value;
                    con.Close();
                    //return (int)result;


                }
            }
        }


        //// TESTING connection
        //internal void OpenCloseConnection()
        //{

        //    SqlConnection _sqlConnection = new SqlConnection(_conn);
        //    _sqlConnection.Open();
        //    Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
        //    _sqlConnection.Close();
        //    Console.WriteLine("Connection is " + _sqlConnection.State.ToString());
        //}



        //    internal List<Book> GetBooks(int inOneParticularBook = -1) {


        //        // TESTing - just mock the list right now
        //        // MockBooks _mockBooks = new MockBooks();
        //        // return _mockBooks.Books;

        //        // implement this with ado.net  
        //        List<Book> _list = new List<Book>();
        //        string _sqlStatement = "SELECT BookID, Title, Book_Description, Book_Price, Book_IsPaperBack, Book_AuthorID_FK, GenreID_FK FROM Book";
        //        using (SqlConnection con = new SqlConnection(_conn))
        //        {
        //            //using (SqlCommand getUserComm = new SqlCommand("spGetBooks", con))
        //            using (SqlCommand _sqlCommand = new SqlCommand(_sqlStatement, con))
        //            {

        //                //getUserComm.CommandType = CommandType.StoredProcedure;
        //                _sqlCommand.CommandType = CommandType.Text;
        //                _sqlCommand.CommandTimeout = 35;
        //                _sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

        //                con.Open();
        //                Book _book;
        //                using (SqlDataReader reader = _sqlCommand.ExecuteReader())
        //                {

        //                    while (reader.Read())
        //                    {
        //                        _book = new Book
        //                        {
        //                            BookID = reader.GetInt32(reader.GetOrdinal("BookID")),
        //                            Title = (string)reader["Title"],
        //                            Description = (string)reader["Book_Description"],
        //                            Price = reader.GetDecimal(reader.GetOrdinal("Book_Price")),
        //                            IsPaperback = (string)reader["Book_IsPaperBack"],
        //                            Author_FK = reader.GetInt32(reader.GetOrdinal("Book_AuthorID_FK")),
        //                            Genre_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK"))
        //                        };
        //                        _list.Add(_book);
        //                    }
        //                }
        //                con.Close();
        //            }
        //        }
        //        return _list;
        //    }



    }
}
