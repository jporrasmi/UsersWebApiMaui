using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebAPIUsers.Models;

namespace WebAPIUsers.Data
{
    public class UserData
    {
        public static bool AddUser(User user) {
            
            using (SqlConnection sqlconnection = new SqlConnection(Conexion.ConexionId))
            {
                SqlCommand cmd = new SqlCommand("storeprocedure_AddUser", sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUser", user.CodUser);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@SecondLastName", user.SecondLasName);

                try {
                    sqlconnection.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex) {
                    return false;
                }
            }
            
        }


        public static bool ModifyUser(User user)
        {

            using (SqlConnection sqlconnection = new SqlConnection(Conexion.ConexionId))
            {
                SqlCommand cmd = new SqlCommand("storeprocedure_UpdateUser", sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUser", user.CodUser);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@SecondLastName", user.SecondLasName);

                try
                {
                    sqlconnection.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }



        public static List<User> ListUser()
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Llego al listar de la base de datos");


            List<User> list = new List<User>();
            using (SqlConnection sqlconnection = new SqlConnection(Conexion.ConexionId))
            {
                SqlCommand cmd = new SqlCommand("storeprocedure_ListUser", sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                User newUser;

                try
                {
                    sqlconnection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newUser = (new User()
                            {
                                CodUser = reader["CodUser"].ToString(),
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                SecondLasName = reader["SecondLastName"].ToString(),
                            });

                            System.Diagnostics.EventLog.WriteEntry("Application", newUser.CodUser);
                            list.Add(newUser);
                        }
                    }

                  
                    return list;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("Application", "Dio error en la excepcion: " +  ex.InnerException.ToString() );
                    return list;
                }

               
            }

        }

        public static User GetUser(String CodUser)
        {
            User user = new User();
            using (SqlConnection sqlconnection = new SqlConnection(Conexion.ConexionId))
            {
                SqlCommand cmd = new SqlCommand("storeprocedure_GetUser", sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUser", CodUser);

                try
                {
                    sqlconnection.Open();
                   //cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User()
                            {
                                CodUser = reader["CodUser"].ToString(),
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                SecondLasName = reader["SecondLastName"].ToString(),
                            };
                        }
                    }

                    return user;

                }
                catch (Exception ex)
                {
                    return user;
                }


            }

        }

        public static bool DeleteUser(String CodUser)
        {

            using (SqlConnection sqlconnection = new SqlConnection(Conexion.ConexionId))
            {
                SqlCommand cmd = new SqlCommand("storeprocedure_DeleteUser", sqlconnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUser", CodUser);

                try
                {
                    sqlconnection.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }



    }
}