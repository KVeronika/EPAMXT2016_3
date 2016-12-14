using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;
using System;

namespace XT2016_3.UserInfo.SqlDal
{
    public class SqlAwardDao : IAwardDao
    {
        public bool Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "add_award";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", award.Title);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                award.Id = (int)cmd.Parameters["@id"].Value;

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "delete_award";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public bool Edit(Award award)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "edit_award";
                cmd.Parameters.AddWithValue("@id", award.Id);
                cmd.Parameters.AddWithValue("@title", award.Title);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_all_awards";
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string title = (string)reader["title"];
                    awards.Add(new Award(id, title));
                }
            }
            return awards;
        }

        public Award GetById(int id)
        {
            List<Award> awards = new List<Award>(this.GetAll());
            var query = awards.Where(award => award.Id == id);
            if (query.Count() == 1)
            {
                foreach (var item in query)
                {
                    return new Award(item.Id, item.Title);
                }
            }
            return null;
        }
    }
}