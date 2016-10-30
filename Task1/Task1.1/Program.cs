using System;

namespace Task1._1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b");
            int b = int.Parse(Console.ReadLine());
            Rectangle rect = new Rectangle(a, b);

            if (a > 0 && b > 0)
            {
                Console.WriteLine("Area = " + rect.Area());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
