using System;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter X coordinate center of the circle");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Y coordinate center of the circle");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter radius of the circle");
                int radius = int.Parse(Console.ReadLine());

                Round circle = new Round(x, y, radius);
                Console.WriteLine($"Length of circle is {circle.Length:.####}");
                Console.WriteLine($"Circle area is {circle.Area:.####}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
