using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1
{
    public class Rectangle
    {

        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A {get; set;}
        public int B { get; set;}

        public int Area()
        {
            return A * B;
        }
    }
}
