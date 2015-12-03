using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageEncoder
{
    using System.Runtime.Remoting.Messaging;

    public class Program
    {
        public static void Main()
        {
            var ts = new TopologicalSort<char>();
            Queue<char> outQueue;
            PriorityQueue<char> res= new PriorityQueue<char>(); 

            bool returnValue;


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char[] l = Console.ReadLine().ToCharArray();
                foreach (var p in l)
                {
                    res.Enqueue(p);
                }

                for (int j = 0; j < l.Length-1; j++)
                {
                    ts.Edge(l[j+1], l[j]);
                }

            }

            returnValue = ts.Sort(out outQueue);
            StringBuilder result = new StringBuilder();

            if (outQueue.Count == 0)
            {
               StringBuilder m = new StringBuilder();
                while (res.Count != 0)
                {
                    m.Append(res.Dequeue());
                }

                Console.WriteLine(m);
                return;
            }

            while (outQueue.Count != 0)
                result.Append(outQueue.Dequeue());
            Console.WriteLine(result);
        }
    }
}
