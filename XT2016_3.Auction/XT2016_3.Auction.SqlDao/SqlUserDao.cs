using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.SqlDao
{
    public class SqlUserDao : IUserDao
    {
        public int Add(string login, byte[] password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "add_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    connection.Open();

                    return (int)(decimal)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public int CanLogin(string login, byte[] password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_user_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);

                    connection.Open();
                    int id = 0;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                    else
                    {
                        return -1;
                    }
                    if (this.ComparePassword(password, id))
                    {
                        return 1;
                    }
                    return -1;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool ChangeRole(int accountId, string rolename)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "change_role_to_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", accountId);
                    cmd.Parameters.AddWithValue("@rolename", rolename);

                    connection.Open();

                    return (cmd.ExecuteNonQuery() > 0);
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool ComparePassword(byte[] camePassword, int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_password_for_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var storedPassword = (byte[])reader["password"];
                        return string.Compare(string.Join("", storedPassword), string.Join("", camePassword)) == 0;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<User> GetAll(string rolename)
        {
            try
            {
                List<User> users = new List<User>();
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_all_accounts_for_rolename";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rolename", rolename);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string login = (string)reader["login"];
                        users.Add(new User(id, login));
                    }
                }
                return users;
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public int GetIdForLogin(string login)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_id_for_login";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);

                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return (int)reader["id"];
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public string[] GetRolesForUser(string login)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_roles_for_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);

                    connection.Open();
                    List<string> roles = new List<string>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add((string)reader["role"]);
                    }
                    return roles.ToArray();
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}