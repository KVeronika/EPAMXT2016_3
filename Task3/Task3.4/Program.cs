using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array = new CycledDynamicArray<int>(new int[] { 1 , 2, 3, 4});

            Console.WriteLine(array[-5]);
        }
    }
}
