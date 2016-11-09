using System;
using System.Collections.Generic;

namespace XT2016_3.UserInfo.DalContracts
{
    public interface IUserAwardDao
    {
        bool AddAward(int userId, int awardId);

        List<int> GetUserAwards(int userId);
    }
}