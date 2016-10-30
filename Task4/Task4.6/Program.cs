using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task4._6
{
    internal class Program
    {
        private static Random rand = new Random();

        private static void Main(string[] args)
        {
            Func<int[], int?> comparePrinciple;
            int[] array = new int[10000];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-10000, 10000);
            }

            Stopwatch timer = new Stopwatch();
            List<double> listTime = new List<double>();
            int? count = 0;
            int n = 400;

            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                count = SimpleFindPositiveElements(array);
                timer.Stop();
                listTime.Add(timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine($"1: time: {listTime[n/2]} count: {count}");

            listTime.Clear();
            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                count = DelegateFindPositiveElements(array, ComparePrinciple);
                timer.Stop();
                listTime.Add(timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine($"2: time: {listTime[n/2]} count: {count}");

            listTime.Clear();
            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                comparePrinciple = delegate (int[] mas)
                {
                    return DelegateFindPositiveElements(mas, ComparePrinciple);
                };
                count = comparePrinciple(array);
                timer.Stop();
                listTime.Add(timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine($"3: time: {listTime[n / 2]} count: {count}");

            listTime.Clear();
            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                comparePrinciple = mas => SimpleFindPositiveElements(mas);
                count = comparePrinciple(array);
                timer.Stop();
                listTime.Add(timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine($"4: time: {listTime[n / 2]} count: {count}");

            listTime.Clear();
            var qweryPositiveElements = array.Where(x => x > 0);
            for (int i = 0; i < n; i++)
            {
                timer.Restart();
                qweryPositiveElements.Count();
                timer.Stop();
                listTime.Add(timer.Elapsed.TotalMilliseconds);
            }
            count = qweryPositiveElements.Count();
            Console.WriteLine($"5: time: {listTime[n / 2]} count: {count}");
        }

        public static int SimpleFindPositiveElements(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int DelegateFindPositiveElements(int[] array, Predicate<int> comparePrinciple)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (comparePrinciple(array[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public static bool ComparePrinciple(int item)
        {
            return item > 0;
        }
    }
}