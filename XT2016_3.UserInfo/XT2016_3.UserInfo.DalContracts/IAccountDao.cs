using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.DalContracts
{
    public interface IAccountDao
    {
        int Add(string login, byte[] password);
        int CanLogin(string login, byte[] password);
        bool ComparePassword(byte[] camePassword, int idOfAccount);
        string[] GetRolesForAccount(string login);
        IEnumerable<Account> GetAll(string rolename);
        bool ChangeRole(int accountId, string rolename);
    }
}
