using System;
using System.Text;

namespace Task1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string");
            string line = Console.ReadLine();
            Console.WriteLine($"Average length of a word is {AverageLengthWord(line):.####}");
        }

        public static double AverageLengthWord(string line)
        {
            int countWords = 0;
            int countLetters = line.Length;
            StringBuilder word = new StringBuilder(line.Length);
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsPunctuation(line[i]) || Char.IsSeparator(line[i]) || Char.IsWhiteSpace(line[i]))
                {
                    countLetters--;
                    if (word.Length != 0)
                    {
                        countWords++;
                        word.Clear();
                    }
                }
                else
                {
                    word.Append(line[i]);
                }
            }
            if (word.Length !=0)
            {
                countWords++;
            }
            return (double)countLetters/countWords;
        }
    }
}
