using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter X");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Y");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter inner radius");
                int inner = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter outer radius");
                int outer = int.Parse(Console.ReadLine());

                Ring ring = new Ring(x, y, inner, outer);
                Console.WriteLine(ring);
                ring.ChangeRadiuses(30, 40);
                Console.WriteLine(ring);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
