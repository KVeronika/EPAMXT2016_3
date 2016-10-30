using System;

namespace Task2._7
{
    class Line: IFigure
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line(Point startPoint, Point endPoint)
        {
            if ((startPoint.X == endPoint.X) && (startPoint.Y == endPoint.Y))
            {
                throw new ArgumentException("Start and End point in Line must be different");
            }
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }
        public double Length
        {
            get
            {
                return (Math.Sqrt((this.StartPoint.X - this.EndPoint.X) * (this.StartPoint.X - this.EndPoint.X) + (this.StartPoint.Y - this.EndPoint.Y) * (this.StartPoint.Y - this.EndPoint.Y)));
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Line:\ncoordinates: Start: ({this.StartPoint.X}, {this.StartPoint.Y}) End: ({this.StartPoint.X}, {this.StartPoint.Y})\n Length: {this.Length}");
        }
    }
}
