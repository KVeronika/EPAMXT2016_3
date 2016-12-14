using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IAccountLogic
    {
        bool Add(string login, string password);
        bool CanLogin(string login, string password);
        string[] GetRolesForAccount(string login);
        IEnumerable<Account> GetAll(string rolename);
        bool ChangeRole(int accountId, string rolename);
    }
}
