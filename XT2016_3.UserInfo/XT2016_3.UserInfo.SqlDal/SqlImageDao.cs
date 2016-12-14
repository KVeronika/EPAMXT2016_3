using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.SqlDal
{
    public class SqlImageDao : IImageDao
    {
        public bool Add(ImageInfo info, Image image)
        {
            var memStr = new MemoryStream();
            image.Save(memStr, ImageFormat.Png);
            byte[] data = memStr.ToArray();

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "add_image";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", info.Name);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                info.Id = (int)cmd.Parameters["@id"].Value;

                return true;
            }
        }

        public bool AddImageToUser(int userId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "add_image_to_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@image_id", imageId);

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public int GetIdByData(byte[] data)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_imageId_by_data";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    int id = (int)cmd.Parameters["@id"].Value;
                    return id;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public ImageData GetThumbnail(int id)
        {
            var data = GetData(id);

            var image = ImageHelper.Resize(Image.FromStream(new MemoryStream(data.Data)), Constants.maxWidth, Constants.maxHeight, reduceOnly: true);
            var memStr = new MemoryStream();
            image.Save(memStr, ImageFormat.Png);

            data.Data = memStr.ToArray();
            return data;

        }

        private static ImageData GetData(int id)
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
                        Data = (byte[])reader["Data"],
                    };
                }

                return null;
            }
        }

        public int GetUserImage(int userId)
        {
            using (var connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_user_image";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                int id = (int)cmd.Parameters["@id"].Value;
                return id;
            }
        }

        public bool AddImageToAward(int awardId, int imageId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "add_image_to_award";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@award_id", awardId);
                cmd.Parameters.AddWithValue("@image_id", imageId);

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public int GetAwardImage(int awardId)
        {
            using (var connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_award_image";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@award_id", awardId);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                int id = (int)cmd.Parameters["@id"].Value;
                return id;
            }
        }
    }
}