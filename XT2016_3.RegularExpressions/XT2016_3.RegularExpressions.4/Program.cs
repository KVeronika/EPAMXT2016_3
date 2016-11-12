using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XT2016_3.RegularExpressions._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "5.7.8e3";
            string patternInt = @"^[\+\-]?\d+(\.\d+)?$";
            string patternFloat = @"^[\+\-]?[1-9](\.\d+)?e[\+\-]?\d+$";

            if (Regex.IsMatch(text, patternInt))
            {
                Console.WriteLine("It's number in natural notation");
            }
            else if (Regex.IsMatch(text, patternFloat))
            {
                Console.WriteLine("It's number in scientist notation");
            }
            else
            {
                Console.WriteLine("Is not number");
            }
        }
    }
}
