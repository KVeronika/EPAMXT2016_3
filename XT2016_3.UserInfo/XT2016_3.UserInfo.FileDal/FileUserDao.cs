using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using XT2016_3.UserInfo.DalContracts;
using XT2016_3.UserInfo.Entities;

namespace XT2016_3.UserInfo.FileDal
{
    public class FileUserDao : IUserDao
    {
        private readonly string fileName;
        private readonly string countOfUsers;

        public FileUserDao()
        {
            this.fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.txt");
            this.countOfUsers = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "counterUsers.txt");
        }

        public bool Add(User user)
        {
            File.WriteAllText(this.countOfUsers, user.Id.ToString());
            File.AppendAllLines(this.fileName, new[] { $"{GetMaxId() + 1}|{user.Name}|{user.DateOfBirth.ToString(Constants.DateOfBirthFormat)}|{user.Age}" });
            return true;
        }

        public bool Delete(int idForDeleteUser)
        {
            User user = this.GetById(idForDeleteUser);
            if (user != null)
            {
                this.RewriteFileWithUsers(idForDeleteUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return File.ReadAllLines(this.fileName)
                    .Select(s => s.Split('|'))
                    .Select(parts => new User(int.Parse(parts[0]), parts[1], DateTime.ParseExact(parts[2], Constants.DateOfBirthFormat, CultureInfo.CurrentCulture)));
            }
            catch (FileNotFoundException)
            {
                return Enumerable.Empty<User>();
            }
        }

        public User GetById(int id)
        {
            return this.GetAll().FirstOrDefault(user => user.Id == id);
        }

        private int GetMaxId()
        {
            try
            {
                return int.Parse(File.ReadAllText(this.countOfUsers, Encoding.Default));
            }
            catch
            {
                File.WriteAllText(this.countOfUsers, "0");
                return 0;
            }
        }

        private void RewriteFileWithUsers(int idForDeleteUser)
        {
            IEnumerable<User> users = this.GetAll().Where(tempUser => tempUser.Id != idForDeleteUser);
            if (!(users.Count() == 0))
            {
                foreach (var item in users)
                {
                    if (item.Id < idForDeleteUser)
                    {
                        File.WriteAllLines(this.fileName, new[] { $"{item.Id}|{item.Name}|{item.DateOfBirth.ToString(Constants.DateOfBirthFormat)}|{item.Age}" });
                    }

                    if (item.Id > idForDeleteUser)
                    {
                        int id = item.Id;
                        File.WriteAllLines(this.fileName, new[] { $"{--id}|{item.Name}|{item.DateOfBirth.ToString(Constants.DateOfBirthFormat)}|{item.Age}" });
                    }
                }

                int maxId = this.GetMaxId();
                File.WriteAllText(this.countOfUsers, (--maxId).ToString());
            }
            else
            {
                File.Create(this.fileName).Close();
            }
        }
    }
}