using System;

namespace Task2._1
{
    class Round
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double radius;

        public Round(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius must be positive");
                }
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
         }

        public double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }
    }
}
