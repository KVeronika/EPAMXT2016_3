using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.SqlDal
{
    public class SqlAccountDao : IAccountDao
    {
        public int Add(string login, byte[] password)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "add_account";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                connection.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["@id"].Value;
            }
        }

        public int CanLogin(string login, byte[] password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "get_account_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output });

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["@id"].Value;
                    if (this.ComparePassword(password, id))
                    {
                        return 1;
                    }
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool ComparePassword(byte[] camePassword, int idOfAccount)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_password_for_account";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_id", idOfAccount);

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

        public IEnumerable<Account> GetAll(string rolename)
        {
            List<Account> accounts = new List<Account>();
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
                    accounts.Add(new Account(id, login));
                }
            }
            return accounts;
        }

        public string[] GetRolesForAccount(string login)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "get_roles_for_account";
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

        public bool ChangeRole(int accountId, string rolename)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "change_role_to_account";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", accountId);
                cmd.Parameters.AddWithValue("@rolename", rolename);

                connection.Open();

                return (cmd.ExecuteNonQuery() > 0);
            }
        }
    }
}
