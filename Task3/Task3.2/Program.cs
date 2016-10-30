using System;
using System.Collections.Generic;

namespace Task3._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter text");
            char[] delimiterChars = { ' ', '.' };
            string line = Console.ReadLine();
            string[] arrayVords = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> frequency = CountFrequency(arrayVords);

            foreach (var item in frequency)
            {
                Console.WriteLine("{0} -- {1:P2}", item.Key, (double)item.Value / arrayVords.Length);
            }
        }

        public static Dictionary<string, int> CountFrequency(string[] arrayVords)
        {
            var frequency = new Dictionary<string, int>(arrayVords.Length, new KeyEqualityComparer());
            for (int i = 0; i < arrayVords.Length; i++)
            {
                if (frequency.ContainsKey(arrayVords[i]))
                {
                    frequency[arrayVords[i]]++;
                }
                else
                {
                    frequency.Add(arrayVords[i], 1);
                }
            }
            return frequency;
        }
    }
}
