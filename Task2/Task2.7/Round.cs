using System;

namespace Task2._7
{
    class Round: IFigure, IArea
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
                return 2 * Math.PI * this.radius;
            }
        }
        public double Area
        {
            get
            {
                return Math.PI * this.radius * this.radius;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Circle:\n center in ({this.X}, {this.Y}) with radius {this.Radius}\nLength: {this.Length} Area: {this.Area}");
        }
    }
}
