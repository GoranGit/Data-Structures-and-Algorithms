namespace _09.Sequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int n;
            int.TryParse(input, out n);

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);

            for (var i=0; i<50;i++)
            {
                var s = queue.Dequeue();
                Console.WriteLine(s);
                queue.Enqueue(s + 1);
                queue.Enqueue((2 * s) + 1);
                queue.Enqueue(s + 2);
            }
        }
    }
}
