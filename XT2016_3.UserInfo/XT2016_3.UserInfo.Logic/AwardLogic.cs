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

        public AwardLogic()
        {
            this.awardDao = DaoProvider.AwardDao;
        }

        public Award Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title of award cannot be null or whitespace", nameof(title));
            }

            Award award = new Award(title);

            if (this.awardDao.Add(award))
            {
                return award;
            }

            throw new InvalidOperationException("Error on user saving");
        }

        public Award[] GetAll()
        {
            return this.awardDao.GetAll().ToArray();
        }
    }
}