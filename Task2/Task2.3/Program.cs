using System;

namespace Task2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter your name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your lastname");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your patronymic");
                string patronymic = Console.ReadLine();
                Console.WriteLine("Enter your date of birth");
                DateTime dateBirth = DateTime.Parse(Console.ReadLine());

                User user1 = new User(name, lastName, patronymic, dateBirth);

                Console.WriteLine(user1); //culture
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
