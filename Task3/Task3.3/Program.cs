using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DynamicArray<int> array = new DynamicArray<int>(new int[] { 1, 2, 5, 5 });
            array.Add(5);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
