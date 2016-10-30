using System;

namespace Task2._7
{
    class Circle: IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double radius;

        public Circle(double x, double y, double radius)
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
        public void ShowInfo()
        {
            Console.WriteLine($"Round:\n center in ({this.X}, {this.Y}) with radius {this.Radius}\n Length: {this.Length}");
        }
    }
}
