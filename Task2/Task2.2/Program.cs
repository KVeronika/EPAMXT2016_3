using System;

namespace Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter A");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter B");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter C");
                int c = int.Parse(Console.ReadLine());

                Triangle triangle = new Triangle(a, b, c);

                Console.WriteLine($"Area of triangle is {triangle.TriangleArea}");
                Console.WriteLine($"Perimetr of triangle is {triangle.TrianglePerimetr}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
