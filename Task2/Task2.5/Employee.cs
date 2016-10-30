using System;

namespace Task2._5
{
    class Employee : User
    {
        private string post;
        private DateTime employmentDate;

        public Employee(string name, string lastName, string patronymic, DateTime dateOfBirth, string post, DateTime employmentDate)
            : base(name, lastName, patronymic, dateOfBirth)
        {
            Post = post;
            EmploymentDate = employmentDate;
        }

        public string Post
        {
            get
            {
                return this.post;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Post should not be empty");
                }
                this.post = value;
            }
        }
        public DateTime EmploymentDate
        {
            get
            {
                return this.employmentDate;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Employment date must be less than the current date");
                }
                if (value < this.DateOfBirth)
                {
                    throw new ArgumentException("Employment date must be more than date of birth");
                }
                this.employmentDate = value;
            }
        }
        public int WorkExperience
        {
            get
            {
                return CountYears(EmploymentDate);
            }
        }

        public override string ToString()
        {
            return (base.ToString() + $"\nPost: {this.Post}\nExperience: {this.WorkExperience}");
        }
    }
}
