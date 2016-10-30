using System;

namespace Task1._7
{
    class Program
    {
        private static Random rand = new Random();

        static void Main()
        {
            int n = 20;
            int[] array = CreateArray(n);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
            QSort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Minimum elment = " + array[0]);
            Console.WriteLine("Maximum elment = " + array[n-1]);
        }

        public static int[] CreateArray(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(0, 100);
            }

            return array;
        }

        public static int partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        public static void QSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            QSort(array, start, pivot - 1);
            QSort(array, pivot + 1, end);
        }

    }
}
