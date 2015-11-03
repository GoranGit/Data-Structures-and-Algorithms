namespace _13.LinkedQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(4);
            numbers.Enqueue(5);
            numbers.Enqueue(6);
            int countOfElements = numbers.Count;
            for (var i = 0; i < countOfElements; i++)
            {
                Console.WriteLine(numbers.Dequeue());
            }
        }
    }
}
