using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.SqlDal
{
    public class SqlUserAwardDao : IUserAwardDao
    {
        public bool AddAward(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "add_award_to_user";
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@award_id", awardId);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public bool DeleteAward(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "delete_award_from_user";
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@award_id", awardId);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public IEnumerable<int> GetUserAwards(int userId)
        {
            List<int> awards = new List<int>();
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_user_awards";
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    awards.Add((int)reader["id_award"]);
                }
            }

            return awards;
        }
    }
}