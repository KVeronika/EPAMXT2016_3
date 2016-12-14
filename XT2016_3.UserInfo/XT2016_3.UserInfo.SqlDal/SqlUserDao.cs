using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.SqlDal
{
    public class SqlUserDao : IUserDao
    {
        public bool Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "add_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                user.Id = (int)cmd.Parameters["@id"].Value;

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "delete_user";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public bool Edit(User user)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "edit_user";
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_all_users";
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                    DateTime dateOfBirth = (DateTime)reader["dateOfBirth"];
                    users.Add(new User(id, name, dateOfBirth));
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            List<User> users = new List<User>(this.GetAll());
            var query = users.Where(user => user.Id == id);
            if (query.Count() == 1)
            {
                foreach (var item in query)
                {
                    return new User(item.Id, item.Name, item.DateOfBirth);
                }
            }
            return null;
        }
    }
}