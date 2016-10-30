using System;

namespace Task1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                DrawTriangles(i, n);
            }
        }

        static void DrawTriangles(int startIndex, int countTriangles)
        {
            for (int j = 1; j <= startIndex; j++)
            {
                for (int k = 1; k < countTriangles - j; k++)
                {
                    Console.Write(' ');
                }
                for (int k = 1; k <= 2 * j - 1; k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
