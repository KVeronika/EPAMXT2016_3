using System;
using System.Collections.Generic;
using System.Linq;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;
        private IAwardDao awardDao;
        private IUserAwardDao userAwardDao;
        private IImageDao imageDao;

        public UserLogic()
        {
            this.userDao = DaoProvider.UserDao;
            this.awardDao = DaoProvider.AwardDao;
            this.userAwardDao = DaoProvider.UserAwardDao;
            this.imageDao = DaoProvider.ImageDao;
        }

        public User Add(string userName, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name cannot be null or whitespace", nameof(userName));
            }

            User user = new User(userName, dateOfBirth);
            if (user.Age > 150)
            {
                throw new ArgumentException("User age cannot be more than 150 years");
            }

            if (this.userDao.Add(user))
            {
                return user;
            }

            throw new InvalidOperationException("Error on user saving");
        }

        public bool AddAward(int userId, int awardId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Id must be positive and not 0", nameof(userId));
            }

            if (awardId <= 0)
            {
                throw new ArgumentException("Id must be positive and not 0", nameof(awardId));
            }

            if (this.userDao.GetById(userId) == null)
            {
                throw new ArgumentException($"User with id {userId} doesn't exist");
            }

            if (this.awardDao.GetById(awardId) == null)
            {
                throw new ArgumentException($"Award with id {awardId} doesn't exist");
            }

            if (!this.userAwardDao.AddAward(userId, awardId))
            {
                throw new InvalidOperationException("Error on add award");
            }

            return true;
        }

        public bool Delete(int idForDelete)
        {
            if (!this.userDao.Delete(idForDelete))
            {
                throw new InvalidOperationException("Error on user deleting");
            }

            return true;
        }

        public User[] GetAll()
        {
            return this.userDao.GetAll().ToArray();
        }

        public Award[] GetUserAwards(int userId)
        {
            List<int> awards = new List<int>(this.userAwardDao.GetUserAwards(userId));
            if (awards.Count == 0)
            {
                return new Award[0];
            }

            Award[] awardsArray = new Award[awards.Count];
            for (int i = 0; i < awardsArray.Length; i++)
            {
                awardsArray[i] = this.awardDao.GetById(awards[i]);
            }

            return awardsArray;
        }

        public bool DeleteAward(int userId, int awardId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Id must be positive and not 0", nameof(userId));
            }

            if (awardId <= 0)
            {
                throw new ArgumentException("Id must be positive and not 0", nameof(awardId));
            }

            if (this.userDao.GetById(userId) == null)
            {
                throw new ArgumentException($"User with id {userId} doesn't exist");
            }

            if (this.awardDao.GetById(awardId) == null)
            {
                throw new ArgumentException($"Award with id {awardId} doesn't exist");
            }

            if (!this.userAwardDao.DeleteAward(userId, awardId))
            {
                throw new InvalidOperationException("Error on delete award");
            }

            return true;
        }

        public User Edit(int userId, string oldUserName, string newUserName, DateTime oldDateOfBirth, DateTime newDateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(newUserName))
            {
                throw new ArgumentException("User name cannot be null or whitespace", nameof(newUserName));
            }
            User user = new User(userId, newUserName, newDateOfBirth);
            if (oldUserName.Equals(newUserName) && oldDateOfBirth.Equals(newDateOfBirth))
            {
                return user;
            }
            if (user.Age > 150)
            {
                throw new ArgumentException("User age cannot be more than 150 years");
            }

            if (this.userDao.Edit(user))
            {
                return user;
            }

            throw new InvalidOperationException("Error on user saving");
        }

        public int GetUserImage(int userId)
        {
            return this.imageDao.GetUserImage(userId);
        }
    }
}