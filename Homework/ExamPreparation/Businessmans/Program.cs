namespace Businessmans
{
    using System;

    public class Program
    {
        static void Main()
        {
            int nLimit;
            Console.Write("Enter the limit for Pascal Triangle: ");

            nLimit = Convert.ToInt32(Console.ReadLine());
    
            //int[,] 

            for (int i = 0; i < nLimit; i++)
            {
                int c = 1;
                Console.WriteLine(" ");

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(c);
                    Console.Write("");

                    c = c * (i - j) / (j + 1);
                }
                Console.Write(" ");
            }
            Console.Write(" ");
            Console.Read();
        } 
    }
}
