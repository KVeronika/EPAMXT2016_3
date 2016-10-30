using System;

namespace Task2._7
{
    class Rectangle:IFigure, IArea
    {
        public Point StartPoint { get; set; }
        private double firstSide;
        private double secondSide;

        public Rectangle(Point startPoint, double firstSide, double secondSide)
        {
            this.StartPoint = startPoint;
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
        }

        public double FirstSide
        {
            get
            {
                return this.firstSide;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle side must be positive");
                }
                this.firstSide = value;
            }
        }
        public double SecondSide
        {
            get
            {
                return this.secondSide;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle side must be positive");
                }
                this.secondSide = value;
            }
        }

        public double Area
        {
            get
            {
                return this.FirstSide * this.SecondSide;
            }
        }
        public double Length
        {
            get
            {
                return (2 * this.FirstSide + 2 * this.SecondSide);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Rectangle:\n with start point ({this.StartPoint.X}, {this.StartPoint.Y}) side length {this.FirstSide} and {this.SecondSide}\nArea: {this.Area} Length: {this.Length}");
        }
    }
}
