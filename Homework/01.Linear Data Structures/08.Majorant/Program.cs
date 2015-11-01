namespace _08.Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, -10, 1, 2, 3, 2, -45, 3, 3, -3, 3, 3, -45, 4, 4, 4, 4, 4, -598, 4, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

            Dictionary<int, int> countOfOccurPerNumber = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (countOfOccurPerNumber.Keys.Contains(number))
                {
                    countOfOccurPerNumber[number]++;
                }
                else
                {
                    countOfOccurPerNumber.Add(number, 1);
                }

                if (countOfOccurPerNumber[number] >= (numbers.Count / 2) + 1)
                {
                    Console.WriteLine(number + " is majorant!");
                    return;
                }
            }

            Console.WriteLine("No majorant in the array!");
        }
    }
}
