using System;

namespace Task4._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sortingUnit = new SortingUnit();
            string[] array1 = new string[] { "abc", "ab", "a", "abd", "ad" };
            string[] array2 = new string[] { "bcd", "bc", "b", "bce", "be" };
            PrintArray(array1);
            sortingUnit.SortingIsFinished += SortingUnit_SortingIsFinished;
            sortingUnit.StarSortingtInTheSameThread(array1, ComparePrinciple);
            Console.WriteLine("SortedArray:");
            PrintArray(array1);
            sortingUnit.StartSortingInAnotherThread(array2, ComparePrinciple);
            Console.WriteLine("SortedArray:");
            PrintArray(array2);
        }

        public static int ComparePrinciple(string string1, string string2)
        {
            if (string1 == null)
            {
                return -1;
            }

            if (string2 == null)
            {
                return 1;
            }

            if (string1.Length < string2.Length)
            {
                return -1;
            }

            if (string1.Length > string2.Length)
            {
                return 1;
            }

            int length = Math.Min(string1.Length, string2.Length);

            for (int i = 0; i < length; i++)
            {
                if (string1[i] < string2[i])
                {
                    return -1;
                }
                else if (string1[i] > string2[i])
                {
                    return 1;
                }
                else
                {
                    continue;
                }
            }

            return 0;
        }

        private static void SortingUnit_SortingIsFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Sorting is finished!!!");
        }

        private static void PrintArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}