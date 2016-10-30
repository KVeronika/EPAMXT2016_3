using System;

namespace Task4._4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };
            Console.WriteLine(arr.ArraySum());

            double[] arr1 = new double[] { 1.0, 2.0, 3.0 };
            Console.WriteLine(arr1.ArraySum());
        }
    }
}