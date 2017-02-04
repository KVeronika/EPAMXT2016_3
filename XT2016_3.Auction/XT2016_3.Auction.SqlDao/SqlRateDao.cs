using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.SqlDao
{
    public class SqlRateDao : IRateDao
    {
        public bool Add(int userId, int productId, decimal rate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "add_rate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@cost", rate);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Rate> GetAll()
        {
            try
            {
                var rates = new List<Rate>();
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_all_rates";
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int userId = (int)reader["id_user"];
                        int productId = (int)reader["id_product"];
                        decimal cost = (decimal)reader["rate"];
                        rates.Add(new Rate(userId, productId, cost));
                    }
                    return rates;
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