using System;
using System.Text;

namespace Task1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TextStyle style = new TextStyle();
            while (true)
            {
                Console.Write("Параметры надписи: " + style);
                Console.WriteLine();
                Console.WriteLine("1: bold");
                Console.WriteLine("2: italic");
                Console.WriteLine("3: underline");
                int keyStyle = int.Parse(Console.ReadLine());
                switch (keyStyle)
                {
                    case 1:
                        {
                            style = style ^ TextStyle.bold;
                            break;
                        }
                    case 2:
                        {
                            style = style ^ TextStyle.italic;
                            break;
                        }
                    case 3:
                        {
                            style = style ^ TextStyle.underline;
                            break;
                        }
                    default:
                        {
                            style = TextStyle.None;
                            break;
                        }
                }
            }
        }
    }
}
