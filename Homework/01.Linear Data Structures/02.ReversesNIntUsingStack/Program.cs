using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReversesNIntUsingStack
{
    public class Program
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            int n;
            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out n))
                {
                    numbers.Push(n);
                }

                input = Console.ReadLine();
            }
            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
