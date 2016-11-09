using System.Collections.Generic;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.DalContracts
{
    public interface IUserDao
    {
        bool Add(User user);

        bool Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}