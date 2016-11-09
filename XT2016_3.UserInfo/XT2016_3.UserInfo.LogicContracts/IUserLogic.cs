using System;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IUserLogic
    {
        User Add(string userName, DateTime dateOfBirth);

        bool Delete(int idForDelete);

        User[] GetAll();

        bool AddAward(int userId, int awardId);

        Award[] GetUserAwards(int userId);
    }
}