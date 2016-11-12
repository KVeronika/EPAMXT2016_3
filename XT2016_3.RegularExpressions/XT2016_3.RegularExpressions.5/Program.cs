using System;
using System.Text.RegularExpressions;

namespace XT2016_3.RegularExpressions._5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = "В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.";
            string pattern = @"([01][0-9])|(2[0-3]):[0-5][0-9]";

            Regex rgx = new Regex(pattern);
            Console.WriteLine($"{rgx.Matches(text).Count}");
        }
    }
}