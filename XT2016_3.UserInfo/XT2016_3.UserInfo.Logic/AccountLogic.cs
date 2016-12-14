using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountDao accountDao;

        public AccountLogic()
        {
            this.accountDao = DaoProvider.AccountDao;
        }

        public bool Add(string login, string password)
        {
            Account account = new Account(login, password);
            SHA256 mySHA256 = SHA256Managed.Create();
            var tempPassword = password.ToCharArray().Select(n => (byte)n).ToArray();
            account.Id = this.accountDao.Add(login, mySHA256.ComputeHash(tempPassword));
            if (account.Id > 0)
            {
                account.Role = this.accountDao.GetRolesForAccount(login)[0];
            }
            return account.Id > 0;
        }

        public bool CanLogin(string login, string password)
        {
            SHA256 mySHA256 = SHA256Managed.Create();
            var tempPassword = password.ToCharArray().Select(n => (byte)n).ToArray();
            return this.accountDao.CanLogin(login, mySHA256.ComputeHash(tempPassword)) > 0;
        }

        public IEnumerable<Account> GetAll(string rolename)
        {
            return this.accountDao.GetAll(rolename);
        }

        public string[] GetRolesForAccount(string login)
        {
            return this.accountDao.GetRolesForAccount(login);
        }

        public bool ChangeRole(int accountId, string rolename)
        {
            return this.accountDao.ChangeRole(accountId, rolename);
        }
    }
}
