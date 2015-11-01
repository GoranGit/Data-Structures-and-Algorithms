using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveNumbersThatOccurOddTimes
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, -10, 1, 2, 3, 2, -45, 3, 3, -3, 3, 3, 4, 4, 4, -45, 4, 4, 4, 4, 4, -598, 4, 3 };
            Dictionary<int, int> countOfOccurPerNumber = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if(countOfOccurPerNumber.Keys.Contains(number))
                {
                    countOfOccurPerNumber[number]++;
                }
                else
                {
                    countOfOccurPerNumber.Add(number, 1);
                }
            }

            List<int> result = numbers.Where(x => countOfOccurPerNumber[x] % 2 == 0).ToList();

            result.ForEach(y => Console.Write(y + " "));
        }
    }
}
