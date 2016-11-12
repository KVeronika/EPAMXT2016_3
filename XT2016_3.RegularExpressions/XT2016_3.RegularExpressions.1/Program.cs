using System;
using System.Text.RegularExpressions;

namespace XT2016_3.RegularExpressions._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = "30-06-2016";
            ////string date1 = @"((0[1-9])|([12][0-9])|(3[01]))-(01|(0[3-9])|(1[0-2]))";
            ////string date2 = @"((0[1-9])|([12][0-9]))-02";

            string dateTemplate = @"(((0[1-9]|[12][0-9]|3[01])-(0[13578]|1[02]))|((0[1-9]|[12][0-9])-02)|((0[1-9]|[12][0-9]|30)-(0[469]|10)))-\d{4}";

            Regex rgx = new Regex(dateTemplate);
            MatchCollection dates = rgx.Matches(text);

            for (int i = 0; i < dates.Count; i++)
            {
                Console.WriteLine($"{dates[i].Value}");
            }
        }
    }
}