using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using XT2016_3.Auction.DaoContracts;
using XT2016_3.Auction.Entities;
using XT2016_3.Auction.LogicContracts;

namespace XT2016_3.Auction.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;
        private IValidator validator;

        public UserLogic()
        {
            this.userDao = DaoProvider.UserDao;
            this.validator = new Validator();
        }

        public bool Add(string login, string password)
        {
            try
            {
                if (!validator.IsValidUserLogin(login) || !validator.IsValidPassword(password))
                {
                    return false;
                }
                if (this.GetIdForLogin(login) < 0)
                {
                    User user = new User(login, password);
                    SHA256 mySHA256 = SHA256Managed.Create();
                    var tempPassword = password.ToCharArray().Select(n => (byte)n).ToArray();
                    user.Id = this.userDao.Add(login, mySHA256.ComputeHash(tempPassword));
                    if (user.Id > 0)
                    {
                        user.Role = this.GetRolesForUser(login)[0];
                    }
                    return user.Id > 0;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CanLogin(string login, string password)
        {
            try
            {
                if (!validator.IsValidUserLogin(login) || !validator.IsValidPassword(password))
                {
                    return false;
                }
                SHA256 mySHA256 = SHA256Managed.Create();
                var tempPassword = password.ToCharArray().Select(n => (byte)n).ToArray();
                return this.userDao.CanLogin(login, mySHA256.ComputeHash(tempPassword)) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ChangeRole(int userId, string rolename)
        {
            try
            {
                if (!validator.IsValidId(userId) || !validator.IsValidRoleName(rolename))
                {
                    return false;
                }
                return this.userDao.ChangeRole(userId, rolename);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<User> GetAll(string rolename)
        {
            try
            {
                if (!validator.IsValidRoleName(rolename))
                {
                    return Enumerable.Empty<User>();
                }
                return this.userDao.GetAll(rolename);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetIdForLogin(string login)
        {
            try
            {
                if (!validator.IsValidUserLogin(login))
                {
                    return -1;
                }
                return this.userDao.GetIdForLogin(login);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            try
            {
                if (!validator.IsValidUserLogin(username))
                {
                    return new string[0];
                }
                return this.userDao.GetRolesForUser(username);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}