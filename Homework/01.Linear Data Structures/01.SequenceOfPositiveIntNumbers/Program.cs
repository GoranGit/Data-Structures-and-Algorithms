namespace _01.SequenceOfPositiveIntNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            int n;
            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                if(int.TryParse(input, out n))
                {
                    numbers.Add(n);
                }

                input = Console.ReadLine();
            }

            var avg = numbers.Average();
            var sum = numbers.Sum();

            Console.WriteLine(avg);
            Console.WriteLine(sum);
        }
    }
}
