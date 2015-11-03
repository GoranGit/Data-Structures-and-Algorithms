namespace _11.LinkedList
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            LinkedList<int> numbers = new LinkedList<int>();

            numbers.FirstElement = new ListItem<int>(4);
            numbers.FirstElement.NextItem = new ListItem<int>(5);
            numbers.FirstElement.NextItem.NextItem = new ListItem<int>(6);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
