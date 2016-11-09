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

        public List<int> GetUserAwards(int userId)
        {
            IEnumerable<Tuple<int, int>> usersWithAwards = File.ReadAllLines(this.fileName)
                .Select(s => s.Split('|'))
                .Select(parts => new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1])));

            List<int> awardsOfUser = new List<int>();

            ////awardsOfUser.Add(int.Parse(usersWithAwards.Where(x => x.Item1 == userId).Select(x => x.Item2).ToString()));
            foreach (var item in usersWithAwards)
            {
                if (item.Item1 == userId)
                {
                    awardsOfUser.Add(item.Item2);
                }
            }

            return awardsOfUser;
        }
    }
}