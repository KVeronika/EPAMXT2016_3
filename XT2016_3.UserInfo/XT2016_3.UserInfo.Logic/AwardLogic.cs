using System;
using System.Linq;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;
using XT2016_3.UserInfo.LogicContracts;

namespace XT2016_3.UserInfo.Logic
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao awardDao;
        private IImageDao imageDao;

        public AwardLogic()
        {
            this.awardDao = DaoProvider.AwardDao;
            this.imageDao = DaoProvider.ImageDao;
        }

        public Award Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title of award cannot be null or whitespace", nameof(title));
            }

            Award award = new Award(title);
            var awards = this.awardDao.GetAll();
            var query = awards.Where(item => item.Title == award.Title);
            if (query.Count() != 0)
            {
                award.Id = query.First().Id;
                return award;
            }
            if (this.awardDao.Add(award))
            {
                return award;
            }

            throw new InvalidOperationException("Error on award saving");
        }

        public bool Delete(int idForDelete)
        {
            if (!this.awardDao.Delete(idForDelete))
            {
                throw new InvalidOperationException("Error on user deleting");
            }

            return true;
        }

        public Award Edit(int awardId, string oldTitle, string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title of award cannot be null or whitespace", nameof(newTitle));
            }

            Award award = new Award(awardId, newTitle);
            if (oldTitle.Equals(newTitle))
            {
                return award;
            }

            if (this.awardDao.Edit(award))
            {
                return award;
            }

            throw new InvalidOperationException("Error on award saving");
        }

        public Award[] GetAll()
        {
            return this.awardDao.GetAll().ToArray();
        }

        public int GetAwardImage(int awardId)
        {
            return this.imageDao.GetAwardImage(awardId);
        }
    }
}