using System;
using System.Linq;
using System.Text;

namespace Task1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first string");
            char[] line1 = Console.ReadLine().ToCharArray();
            Console.WriteLine("Enter second string");
            string line2 = Console.ReadLine();
            StringBuilder answerString = CharDoubler(line1, line2);
            Console.WriteLine(answerString);
        }

        public static StringBuilder CharDoubler(char[] array, string word)
        {
            StringBuilder answer = new StringBuilder(array.Length*2);
            for (int i = 0; i < array.Length; i++)
            {
                answer.Append(array[i]);
                if (word.Contains(array[i]))
                {
                    answer.Append(array[i]);
                }
            }
            return answer;
        }
    }
}
