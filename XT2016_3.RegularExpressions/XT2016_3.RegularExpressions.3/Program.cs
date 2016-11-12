using System;
using System.Text.RegularExpressions;

namespace XT2016_3.RegularExpressions._3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = "Иван: i--@mail.ru, Петр: p_ivanov@mail.rol.ru";
            string pattern = @"[A-Za-z0-9]+([\w.-]*[A-Za-z0-9]+)?@([A-Za-z0-9]+\w*[A-Za-z0-9]+.)+[A-Za-z0-9]+";

            Regex rgx = new Regex(pattern);
            MatchCollection emails = rgx.Matches(text);

            for (int i = 0; i < emails.Count; i++)
            {
                Console.WriteLine(emails[i].Value);
            }
        }
    }
}