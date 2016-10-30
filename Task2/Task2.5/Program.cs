using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._5
{
    class Program
    {
        static void Main()
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
                Console.WriteLine("Enter post in company");
                string post = Console.ReadLine();
                Console.WriteLine("Enter employment date");
                DateTime employmentDate = DateTime.Parse(Console.ReadLine());

                Employee employee1 = new Employee(name, lastName, patronymic, dateBirth, post, employmentDate);

                Console.WriteLine(employee1); //culture
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
