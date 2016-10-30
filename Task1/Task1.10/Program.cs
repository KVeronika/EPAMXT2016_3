using System;

namespace Task1._10
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int n = 2;
            int[,] array = CreateArray(n);
            Print(array);
            Console.WriteLine("Sum of even elements is " + SumOfEnum(array));
        }

        public static int[,] CreateArray(int n)
        {
            int[,] array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rand.Next(-50, 50);
                }
            }
            return array;
        }

        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int SumOfEnum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i % 2; j < array.GetLength(1); j += 2)
                {
                    sum += array[i, j];
                }
            }
            return sum;
        }
    }
}
