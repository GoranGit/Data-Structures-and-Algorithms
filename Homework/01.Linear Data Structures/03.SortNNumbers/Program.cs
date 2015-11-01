namespace _03.SortNNumbers
{
    using System;
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
                if (int.TryParse(input, out n))
                {
                    numbers.Add(n);
                }

                input = Console.ReadLine();
            }

            numbers.Sort();
            numbers.ForEach(x => Console.Write(x + " "));
        }
    }
}
