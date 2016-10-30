using System;

namespace Task2._3
{
    class User
    {
        private string firstName, lastName, patronymic;
        private DateTime dateOfBirth;

        public User(string firstName, string lastName, string patronymic, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name should not be empty");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name should not be empty");
                }
                this.lastName = value;
            }
        }
        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Patronymic shouldn't be empty");
                }
                else
                {
                    this.patronymic = value;
                }
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            private set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of birth must be less than the current date");
                }
                if (CountYears(this.DateOfBirth) > 150)
                {
                    throw new ArgumentException("Age must be less than 150 years");
                }
                this.dateOfBirth = value;
            }
        }
        public int Age
        {
            get
            {
                return CountYears(this.DateOfBirth);
            }
        }

        public override string ToString()
        {
            return ($"User name: {this.FirstName} {this.LastName} {this.Patronymic}\nBirth date: {this.DateOfBirth:d}\nAge: {this.Age}");
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
