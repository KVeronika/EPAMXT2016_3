using System;

namespace Task2._7
{
    class Ring
    {
        private Round innerRound;
        private Round outerRound;
        private double innerRadius;
        private double outerRadius;

        public Ring(double x, double y, double innerRad, double outerRad)
        {
            if (!RadiusesIsCorrect(innerRad, outerRad))
            {
                throw new ArgumentException("Inner radius must be less than outer!");
            }
            this.innerRound = new Round(x, y, this.InnerRadius = innerRad);
            this.outerRound = new Round(x, y, this.OuterRadius = outerRad);
        }

        public double InnerRadius
        {
            get
            {
                return this.innerRadius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Inner radius must be more than 0");
                }
                if (value > this.OuterRadius)
                {
                    throw new ArgumentException("Inner radius must be less than outer");
                }
                innerRadius = value;
            }
        }
        public double OuterRadius
        {
            get
            {
                return this.outerRadius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Outer radius must be more than 0");
                }
                if (value < this.InnerRadius)
                {
                    throw new ArgumentException("Outner radius must be more than inner");
                }
                outerRadius = value;
            }
        }

        public double Area
        {
            get
            {
                return this.outerRound.Area - this.innerRound.Area;
            }
        }
        public double Length
        {
            get
            {
                return (this.innerRound.Length + this.outerRound.Length);
            }
        }

        private static bool RadiusesIsCorrect(double inner, double outer)
        {
            if (inner < outer)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return ($"Center in {{{this.innerRound.X}, {this.innerRound.Y}}} \nArea: {this.Area}\nLength: {this.Length}");
        }
    }
}
