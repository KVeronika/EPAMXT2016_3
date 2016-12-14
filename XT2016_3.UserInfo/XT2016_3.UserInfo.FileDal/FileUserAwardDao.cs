using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XT2016_3.UserInfo.DalContracts;

namespace XT2016_3.UserInfo.FileDal
{
    public class FileUserAwardDao : IUserAwardDao
    {
        private readonly string fileName;

        public FileUserAwardDao()
        {
            this.fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userAward.txt");
        }

        public bool AddAward(int userId, int awardId)
        {
            File.AppendAllLines(this.fileName, new[] { $"{userId}|{awardId}" });
            return true;
        }

        public bool DeleteAward(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetUserAwards(int userId)
        {
            var usersWithAwards = File.ReadAllLines(this.fileName)
                .Select(s => s.Split('|'))
                .Select(parts => new { UserId = int.Parse(parts[0]), AwardId = int.Parse(parts[1]) });

            List<int> awardsOfUser = new List<int>();

            awardsOfUser.AddRange(usersWithAwards.Where(x => x.UserId == userId).Select(x => x.AwardId));

            //foreach (var item in usersWithAwards)
            //{
            //    if (item.Item1 == userId)
            //    {
            //        awardsOfUser.Add(item.Item2);
            //    }
            //}

            return awardsOfUser;
        }
    }
}