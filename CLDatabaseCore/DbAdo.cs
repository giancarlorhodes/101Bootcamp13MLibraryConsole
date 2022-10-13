using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CLCommonCore.DTO;

namespace CLDatabaseCore
{
    public class DbAdo
    {
        // data
        private string _conn;

        //// Constructor
        //public DbAdo()
        //{
        //    _conn = this.GetConnectionString();
        //}

        public DbAdo(string conn)
        {
            _conn = conn;
        }

        // methods
        //private string GetConnectionString()
        //{
        //    return ConfigurationManager.ConnectionStrings["DBCONN"].ConnectionString;
        //}

        // log errors
        // TODO: log to file
        public int LogException(Exception inException) 
        {
            int _pk = 0;

            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("uspCreateLogException", con))
                {
                 
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 30;

                    SqlParameter _parmStackTrace = _sqlCommand.CreateParameter();
                    _parmStackTrace.DbType = DbType.String;
                    _parmStackTrace.ParameterName = "@parmStackTrace";
                    _parmStackTrace.Value = inException.StackTrace;
                    _sqlCommand.Parameters.Add(_parmStackTrace);

                    SqlParameter _parmMessage = _sqlCommand.CreateParameter();
                    _parmMessage.DbType = DbType.String;
                    _parmMessage.ParameterName = "@parmMessage";
                    _parmMessage.Value = inException.Message;
                    _sqlCommand.Parameters.Add(_parmMessage);

                    SqlParameter _parmSource = _sqlCommand.CreateParameter();
                    _parmSource.DbType = DbType.String;
                    _parmSource.ParameterName = "@parmSource";
                    _parmSource.Value = inException.Source;
                    _sqlCommand.Parameters.Add(_parmSource);

                    SqlParameter _parmURL = _sqlCommand.CreateParameter();
                    _parmURL.DbType = DbType.String;
                    _parmURL.ParameterName = "@parmURL";
                    _parmURL.Value = DBNull.Value; // TODO maybe in include URL in web app
                    _sqlCommand.Parameters.Add(_parmURL);

                    SqlParameter _parmLogDate = _sqlCommand.CreateParameter();
                    _parmLogDate.DbType = DbType.DateTime;
                    _parmLogDate.ParameterName = "@parmLogDate";
                    _parmLogDate.Value = DateTime.Now;
                    _sqlCommand.Parameters.Add(_parmLogDate);

                    SqlParameter _paramExceptionLoggingIDReturn = _sqlCommand.CreateParameter();
                    _paramExceptionLoggingIDReturn.DbType = DbType.Int32;
                    _paramExceptionLoggingIDReturn.ParameterName = "@parmOutExceptionLoggingID";
                    var pk = _sqlCommand.Parameters.Add(_paramExceptionLoggingIDReturn);
                    _paramExceptionLoggingIDReturn.Direction = ParameterDirection.Output;
                  
                    con.Open();
                    _sqlCommand.ExecuteNonQuery();   // calls the sp      
                    _pk = (int)_paramExceptionLoggingIDReturn.Value; // has the auto incremented value returned
                    con.Close();
                    return _pk;                  
                }
            }
        }

        #region Role

        // "R - READ" of CRUD
        public List<RoleDTO> GetRoles()
        {
            List<RoleDTO> _list = new List<RoleDTO>();
            using (SqlConnection con = new SqlConnection(_conn))
            {
                using (SqlCommand _sqlCommand = new SqlCommand("uspGetRole", con))
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.CommandTimeout = 10;
                    //_sqlCommand.Parameters.AddWithValue("@BookID", inOneParticularBook);

                    con.Open();
                    RoleDTO _role;
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _role = new RoleDTO
                            {
                                RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                RoleName = (string)reader["RoleName"],
                                Comment = reader["Comment"] is DBNull ? "" : (string)reader["Comment"],
                                DateModified = reader.GetDateTime(reader.GetOrdinal("DateModified")),
                                ModifiedByUserId = reader.GetInt32(reader.GetOrdinal("ModifiedByUserID"))
                                //Price = reader.GetDecimal(reader.GetOrdinal("Book_Price")),
                                //IsPaperback = (string)reader["Book_IsPaperBack"],
                                //Author_FK = reader.GetInt32(reader.GetOrdinal("Book_AuthorID_FK")),
                                //Genre_FK = reader.GetInt32(reader.GetOrdinal("GenreID_FK"))
                            };
                            _list.Add(_role); // add current object to the list object
                        }
                    }
                    con.Close();
                }
            }
            return _list;
        }


        // "C - INSERT" of CRUD
        public int CreateRole(RoleDTO r)
        {
            int _result = 0;

            try
            {

                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("uspCreateRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;

                        SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
                        _paramRoleName.DbType = DbType.String;
                        _paramRoleName.ParameterName = "@ParamRoleName";
                        _paramRoleName.Value = r.RoleName;
                        _sqlCommand.Parameters.Add(_paramRoleName);

                        SqlParameter _paramComment = _sqlCommand.CreateParameter();
                        _paramComment.DbType = DbType.String;
                        _paramComment.ParameterName = "@ParmComment";
                        if (r.Comment == null)
                        {
                            _paramComment.Value = DBNull.Value;  //(r.Comment == null) ? DBNull.Value : r.Comment;
                        }
                        else 
                        {
                            _paramComment.Value = r.Comment;
                        }
                        
                        _sqlCommand.Parameters.Add(_paramComment);

                        SqlParameter _paramDateModified = _sqlCommand.CreateParameter();
                        _paramDateModified.DbType = DbType.String;
                        _paramDateModified.ParameterName = "@ParmDateModified";
                        _paramDateModified.Value = r.DateModified;
                        _sqlCommand.Parameters.Add(_paramDateModified);

                        SqlParameter _paramModifiedByUserID = _sqlCommand.CreateParameter();
                        _paramModifiedByUserID.DbType = DbType.Int32;
                        _paramModifiedByUserID.ParameterName = "@ParmModifiedByUserID";
                        _paramModifiedByUserID.Value = r.ModifiedByUserId;
                        _sqlCommand.Parameters.Add(_paramModifiedByUserID);

                        SqlParameter _paramRoleIDReturn = _sqlCommand.CreateParameter();
                        _paramRoleIDReturn.DbType = DbType.Int32;
                        _paramRoleIDReturn.ParameterName = "@ParamOutRoleID";
                        var pk = _sqlCommand.Parameters.Add(_paramRoleIDReturn);
                        _paramRoleIDReturn.Direction = ParameterDirection.Output;

                        con.Open();
                        _sqlCommand.ExecuteNonQuery();   // calls the sp 
                        _result = (int)_paramRoleIDReturn.Value; // has the auto incremented value returned
                        con.Close();
                        return _result; // primary key
                    }
                }
            }
            catch (Exception ex)
            {
                _result = 0;
                this.LogException(ex);

            }

            return _result;
        }


        // "D - DELETE" of CRUD  
        public void DeleteRole(RoleDTO r)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("uspDeleteRole", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;
                        SqlParameter _parameter = _sqlCommand.CreateParameter();
                        _parameter.DbType = DbType.Int32;
                        _parameter.ParameterName = "@parmRoleID";
                        _parameter.Value = r.RoleID;
                        _sqlCommand.Parameters.Add(_parameter);

                        con.Open();
                        _sqlCommand.ExecuteNonQuery();   // calls the sp                 
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
            }
          
        }

        //public void UpdateRole(Role r)
        //{
        //    using (SqlConnection con = new SqlConnection(_conn))
        //    {
        //        using (SqlCommand _sqlCommand = new SqlCommand("spUpdateRole", con))
        //        {
        //            _sqlCommand.CommandType = CommandType.StoredProcedure;
        //            _sqlCommand.CommandTimeout = 30;

        //            SqlParameter _paramRoleName = _sqlCommand.CreateParameter();
        //            _paramRoleName.DbType = DbType.String;
        //            _paramRoleName.ParameterName = "@ParamRoleName";
        //            _paramRoleName.Value = r.RoleName;
        //            _sqlCommand.Parameters.Add(_paramRoleName);

        //            SqlParameter _paramRoleID = _sqlCommand.CreateParameter();
        //            _paramRoleID.DbType = DbType.Int32;
        //            _paramRoleID.ParameterName = "@ParamRoleID";
        //            _paramRoleID.Value = r.RoleID;
        //            _sqlCommand.Parameters.Add(_paramRoleID);

        //            con.Open();
        //            _sqlCommand.ExecuteNonQuery();   // calls the sp                 
        //            con.Close();
        //        }
        //    }
        //}

        #endregion

        #region User
        public List<UserDTO> GetUsers()
        {
            List<UserDTO> _list = new List<UserDTO>();
            // TODO - add try catch 

            try
            {

                using (SqlConnection con = new SqlConnection(_conn))
                {
                    using (SqlCommand _sqlCommand = new SqlCommand("uspGetUser", con))
                    {
                        _sqlCommand.CommandType = CommandType.StoredProcedure;
                        _sqlCommand.CommandTimeout = 30;

                        con.Open();
                        UserDTO _user;

                        using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _user = new UserDTO
                                {
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    LastName = (string)reader["LastName"],
                                    FirstName = (string)reader["FirstName"],
                                    UserName = (string)reader["UserName"],
                                    Password = (string)reader["Password"],
                                    RoleID_FK = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                    Role = new RoleDTO()
                                    {
                                        RoleID = reader.GetInt32(reader.GetOrdinal("RoleID")),
                                        RoleName = (string)reader["RoleName"]
                                    }
                                };
                                _list.Add(_user);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                this.LogException(ex);
            }

            return _list;
        }


        public void CreateUser(UserDTO u)
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




        #endregion


    }
}