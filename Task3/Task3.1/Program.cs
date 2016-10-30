using System;
using System.Collections.Generic;

namespace Task3._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = int.Parse(Console.ReadLine());

            var que = new Queue<int>(n);
            FillQueue(n, que);

            Console.WriteLine($"Alive is - {Deletion(que)}");
        }

        public static int Deletion(Queue<int> que)
        {
            bool flag = true;

            while (que.Count > 1)
            {
                WriteStep(que);
                if (flag)
                {
                    que.Enqueue(que.Dequeue());
                }
                else
                {
                    que.Dequeue();
                }

                flag = !flag;
            }

            return que.Dequeue();
        }

        public static void FillQueue(int n, Queue<int> que)
        {
            for (int i = 1; i <= n; i++)
            {
                que.Enqueue(i);
            }
        }

        public static void WriteStep(Queue<int> que)
        {
            foreach (var item in que)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
