namespace ADTStack
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);
            myStack.Push(8);
            myStack.Push(9);
            var initialCount = myStack.Count;
            for (var i = 0; i < initialCount; i++)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    }
}
