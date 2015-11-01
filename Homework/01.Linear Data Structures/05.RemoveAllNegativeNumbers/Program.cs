using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveAllNegativeNumbers
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, -10, 1, 2, 3, 2, -45, 3, 3, -3, 3, 3, 4, 4, 4, -40, 4, 4, 4, 4, 4, -598, 4, 3 };
            List<int> result = numbers.Where(x => x >= 0).ToList();
            result.ForEach(y => Console.Write(y + " "));
        }
    }
}
