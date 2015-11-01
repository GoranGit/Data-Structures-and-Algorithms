using System;
using System.Collections.Generic;

namespace _10.ShortestSequenceOfOperations
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M: ");
            int m = int.Parse(Console.ReadLine());

            Queue<QueueItem> queue = new Queue<QueueItem>();

            queue.Enqueue(new QueueItem { Value = n, Previous = null});
            while(true)
            {
                QueueItem item = queue.Dequeue();
                if (item.Value < m)
                {
                    queue.Enqueue(new QueueItem { Value = item.Value + 2, Previous = item });
                    queue.Enqueue(new QueueItem { Value = item.Value + 1, Previous = item });
                    queue.Enqueue(new QueueItem { Value = item.Value * 2, Previous = item });
                }

                if (item.Value == m)
                {
                    PrintResult(item);
                    return;
                }
            }
        }

        private static void PrintResult(QueueItem item)
        {
            Stack<int> result = new Stack<int>();

            while (item != null)
            {
                result.Push(item.Value);
                item = item.Previous;
            }

            while (result.Count != 0)
            {
                Console.Write(result.Pop() + " ->");
            }
        }
    }
}
