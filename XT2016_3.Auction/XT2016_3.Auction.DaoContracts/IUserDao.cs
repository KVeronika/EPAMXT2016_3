using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.DaoContracts
{
    public interface IUserDao
    {
        int Add(string login, byte[] password);

        int CanLogin(string login, byte[] password);

        bool ComparePassword(byte[] camePassword, int userId);

        string[] GetRolesForUser(string login);

        IEnumerable<User> GetAll(string rolename);

        bool ChangeRole(int accountId, string rolename);

        int GetIdForLogin(string login);
    }
}