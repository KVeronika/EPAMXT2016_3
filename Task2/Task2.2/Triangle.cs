using System;

namespace Task2._2
{
    class Triangle
    {
        private int a, b, c;

        public Triangle(int a, int b, int c)
        {
            if (ExistTriangle(a, b, c))
            {
                A = a;
                B = b;
                C = c;
            }
            else
            {
                throw new ArgumentException("Triangle does not exist");
            }
        }

        public int A
        {
            get
            {
                return this.a;
            }
            set
            {
                if (!ExistTriangle(value, B, C))
                {
                    throw new ArgumentException("Side length invalid");
                }
                this.a = value;
            }
        }
        public int B
        {
            get
            {
                return this.b;
            }
            set
            {
                if (!ExistTriangle(A, value, C))
                {
                    throw new ArgumentException("Side length invalid");
                }
                this.b = value;
            }
        }
        public int C
        {
            get
            {
                return this.c;
            }
            set
            {
                if (!ExistTriangle(A, B, c))
                {
                    throw new ArgumentException("Side length invalid");
                }
                this.c = value;
            }
        }

        public double Area
        {
            get
            {
                double p = (double)(Perimetr) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }
        public int Perimetr
        {
            get
            {
                return this.A + this.B + this.C;
            }
        }

        public static bool ExistTriangle(int a, int b, int c)
        {
            return ((a < b + c) && (b < a + c) && (c < a + b)) ;
        }
    }
}
