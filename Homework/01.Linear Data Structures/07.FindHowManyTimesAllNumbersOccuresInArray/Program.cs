using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FindHowManyTimesAllNumbersOccuresInArray
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, -10, 1, 2, 3, 2, -45, 3, 3, -3, 3, 3, 4, 4, 4, -45, 4, 4, 4, 4, 4, -598, 4, 3 };
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
            }

            foreach(var number in countOfOccurPerNumber)
            {
                Console.WriteLine(number.Key + " -> " + number.Value);
            }
        }
    }
}
