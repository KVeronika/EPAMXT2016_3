using System;
using System.Data;
using System.Data.SqlClient;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.SqlDao
{
    public class SqlImageDao : IImageDao
    {
        public bool Add(ImageData data)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "add_image";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@content_type", data.ContentType);
                    cmd.Parameters.AddWithValue("@data", data.Data);

                    connection.Open();
                    data.Id = (int)(decimal)cmd.ExecuteScalar();

                    return true;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public bool AddImageToProduct(int productId, int imageId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "add_image_to_product";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.AddWithValue("@image_id", imageId);

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

        public ImageData GetData(int id)
        {
            try
            {
                using (var connection = new SqlConnection(Constants.connectionString))
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "get_image_data";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new ImageData
                        {
                            Data = (byte[])reader["data"],
                            ContentType = (string)reader["content_type"]
                        };
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public int GetIdByData(byte[] data)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_imageId_by_data";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", data);

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

        public int GetProductImage(int productId)
        {
            try
            {
                using (var connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_product_image";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    int id = (int)cmd.Parameters["@id"].Value;
                    return id;
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