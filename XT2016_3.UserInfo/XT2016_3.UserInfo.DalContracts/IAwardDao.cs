using System.Collections.Generic;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.DalContracts
{
    public interface IAwardDao
    {
        bool Add(Award award);

        bool Delete(int id);

        bool Edit(Award award);

        IEnumerable<Award> GetAll();

        Award GetById(int id);
    }
}