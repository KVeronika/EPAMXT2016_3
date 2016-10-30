using System;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
