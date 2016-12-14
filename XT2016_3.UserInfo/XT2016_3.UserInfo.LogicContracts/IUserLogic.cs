using System;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.LogicContracts
{
    public interface IUserLogic
    {
        User Add(string userName, DateTime dateOfBirth);

        User Edit(int userId, string oldUserName, string newUserName, DateTime oldDateOfBirth, DateTime newDateOfBirth);

        bool Delete(int idForDelete);

        User[] GetAll();

        bool AddAward(int userId, int awardId);

        bool DeleteAward(int userId, int awardId);

        Award[] GetUserAwards(int userId);

        int GetUserImage(int userId);
    }
}