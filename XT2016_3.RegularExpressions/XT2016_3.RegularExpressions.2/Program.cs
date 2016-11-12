using System;
using System.Text;
using System.Text.RegularExpressions;

namespace XT2016_3.RegularExpressions._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            string text = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами";
            string pattern = @"</?[A-Za-z]+( [A-Za-z]+=""[A-Za-z]+"")*>";

            Regex rgx = new Regex(pattern);
            MatchCollection htmlTags = rgx.Matches(text);

            StringBuilder ans = new StringBuilder(text);
            for (int i = 0; i < htmlTags.Count; i++)
            {
                ans.Replace(htmlTags[i].Value, "_");
            }

            Console.WriteLine(ans);
        }
    }
}