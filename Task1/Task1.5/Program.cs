using System;

namespace Task1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3, b = 5, n = 1000;
            Console.WriteLine(ProgressionSum(a, n) + ProgressionSum(b, n) - ProgressionSum(a*b, n));
        }

        public static int ProgressionSum(int a, int n)
        {
            return (a + n) * (n / a) / 2;
        }
    }
}
