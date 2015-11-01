namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 1, 1, 2, 3, 2, 4, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 4, 3 };

            List<int> resultList = FindLongestSequence(numbers);
            resultList.ForEach(x => Console.WriteLine(x));
        }

        public static List<int> FindLongestSequence(List<int> list)
        {
            List<int> resul = new List<int>();
            int maxCountOfNumbersInSequence = 1;
            int numberWithLongestSequence = 0;

            int counter = 0;
            int num = list.FirstOrDefault();

            for (var i = 0; i < list.Count; i++)
            {
                if (num == list[i])
                {
                    counter++;
                    num = list[i];
                }
                else
                {
                    if (maxCountOfNumbersInSequence < counter)
                    {
                        maxCountOfNumbersInSequence = counter;
                        numberWithLongestSequence = num;
                    }

                    counter = 1;
                    num = list[i];
                }
            }

            var result = Enumerable.Repeat(numberWithLongestSequence, maxCountOfNumbersInSequence);
            return result.ToList();
        }
    }
}
