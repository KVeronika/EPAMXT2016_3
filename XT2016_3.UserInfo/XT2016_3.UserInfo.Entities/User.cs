using System;

namespace XT2016_3.UserInfo.Entities
{
    public class User
    {
        public User(string userName, DateTime dateOfBirth)
        {
            this.Name = userName;
            this.DateOfBirth = dateOfBirth;
        }

        public User(int id, string name, DateTime dateTime)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateTime;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; }

        public int Age
        {
            get
            {
                return CountYears(this.DateOfBirth);
            }
        }

        public static int CountYears(DateTime dateOfBirth)
        {
            int answer = 0;
            if (dateOfBirth.Month < DateTime.Now.Month)
            {
                answer = DateTime.Now.Year - dateOfBirth.Year;
            }
            else
            {
                if (dateOfBirth.Day < DateTime.Now.Day)
                {
                    answer = DateTime.Now.Year - dateOfBirth.Year;
                }
                else
                {
                    answer = DateTime.Now.Year - dateOfBirth.Year - 1;
                }
            }

            return answer;
        }
    }
}