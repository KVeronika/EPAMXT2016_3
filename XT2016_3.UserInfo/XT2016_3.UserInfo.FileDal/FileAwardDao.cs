using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.FileDal
{
    public class FileAwardDao : IAwardDao
    {
        private readonly string fileName;
        private readonly string countOfAwards;

        public FileAwardDao()
        {
            this.fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "awards.txt");
            this.countOfAwards = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "counterAwards.txt");
        }

        public bool Add(Award award)
        {
            File.WriteAllText(this.countOfAwards, award.Id.ToString());
            File.AppendAllLines(this.fileName, new[] { $"{GetMaxId() + 1}|{award.Title}" });
            return true;
        }

        public IEnumerable<Award> GetAll()
        {
            try
            {
                return File.ReadAllLines(this.fileName)
                    .Select(s => s.Split('|'))
                    .Select(parts => new Award(int.Parse(parts[0]), parts[1]));
            }
            catch (FileNotFoundException)
            {
                return Enumerable.Empty<Award>();
            }
        }

        public Award GetById(int id)
        {
            return this.GetAll().FirstOrDefault(award => award.Id == id);
        }

        private int GetMaxId()
        {
            try
            {
                return int.Parse(File.ReadAllText(this.countOfAwards, Encoding.Default));
            }
            catch
            {
                File.WriteAllText(this.countOfAwards, "0");
                return 0;
            }
        }
    }
}
