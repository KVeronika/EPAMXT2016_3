using System;

namespace Task1._9
{
    class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            int n = 20;
            int[] array = CreateArray(n);
            int sum = NonNegativeSum(array);
            Print(array);
            Console.WriteLine("Non-negative sum is " + sum);
        }

        public static int[] CreateArray(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            return array;
        }

        public static int NonNegativeSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }
            return sum;
        }

        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
