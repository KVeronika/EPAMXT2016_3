using System.Collections.Generic;
using XT2016_3.Auction.Entities;

namespace XT2016_3.Auction.LogicContracts
{
    public interface IUserLogic
    {
        bool Add(string login, string password);

        bool CanLogin(string login, string password);

        string[] GetRolesForUser(string login);

        IEnumerable<User> GetAll(string rolename);

        bool ChangeRole(int userId, string rolename);

        int GetIdForLogin(string login);
    }
}