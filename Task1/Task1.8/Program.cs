using System;

namespace Task1._8
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            int n = 2;
            int[,,] array = CreateArray(n);
            Print3DArray(array);
            ChangeNegativeElements(array);
            Print3DArray(array);
        }

        public static int[,,] CreateArray(int n)
        {
            int[,,] array = new int[n, n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        array[i, j, k] = rand.Next(-100, 100);
                    }
                }
            }
            return array;
        }

        public static void ChangeNegativeElements(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] < 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static void Print3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    Console.WriteLine("level: {0}", k);
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write("a[{0},{1},{2}] = {3} ", i, j, k, array[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
