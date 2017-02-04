using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.SqlDao
{
    public class SqlProductDao : IProductDao
    {
        public bool Add(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "add_product";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@current_rate", product.CurrentRate);
                    cmd.Parameters.AddWithValue("@buy_now", product.BuyNow);
                    cmd.Parameters.AddWithValue("@ending_date", product.EndingDate);

                    connection.Open();
                    product.Id = (int)(decimal)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool AddProductToUser(int userId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "add_product_to_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@product_id", productId);

                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteForAdmin(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "delete_product_for_admin";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", productId);

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

        public bool DeleteForUser(int userId, int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "delete_product_for_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@product_id", productId);

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

        public bool Edit(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "edit_product";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@current_rate", product.CurrentRate);
                    cmd.Parameters.AddWithValue("@buy_now", product.BuyNow);
                    cmd.Parameters.AddWithValue("@ending_date", product.EndingDate);

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

        public IEnumerable<Product> GetAll()
        {
            try
            {
                var products = new List<Product>();
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "get_all_products";

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string name = (string)reader["name"];
                        string description = (string)reader["description"];
                        decimal currentRate = (decimal)reader["current_rate"];
                        DateTime endingDate = (DateTime)reader["ending_date"];
                        bool buyNow = (bool)reader["buy_now"];
                        products.Add(new Product(id, name, description, currentRate, endingDate, buyNow));
                    }
                    return products;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public IEnumerable<Product> GetAllForUser(int userId)
        {
            try
            {
                var products = new List<Product>();
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_products_of_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(this.GetById((int)reader["id_product"]));
                    }
                    return products;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                List<Product> products = new List<Product>(this.GetAll());
                var query = products.Where(product => product.Id == id);
                if (query.Count() == 1)
                {
                    foreach (var item in query)
                    {
                        return new Product(item.Id, item.Name, item.Description, item.CurrentRate, item.EndingDate, item.BuyNow);
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}