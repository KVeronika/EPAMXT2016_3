using System;

namespace Task2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyString first = new MyString("abcd");
                MyString second = new MyString("abc");


                Console.WriteLine(first.SearchIndex('e'));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
