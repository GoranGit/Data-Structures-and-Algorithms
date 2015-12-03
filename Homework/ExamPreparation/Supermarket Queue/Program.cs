namespace Supermarket_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            BigList<string> names = new BigList<string>();
            Dictionary<string,int> namesCounter= new Dictionary<string, int>();


            string[] input = Console.ReadLine().Split(' ');

            StringBuilder result = new StringBuilder();

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Append":
                        {
                            names.Add(input[1]);
                            if (!namesCounter.ContainsKey(input[1]))
                            {
                                namesCounter.Add(input[1], 1);
                            }
                            else
                            {
                                namesCounter[input[1]]++;
                            }

                            result.AppendLine("OK");
                            break;
                        }
                    case "Insert":
                        {
                            var position = int.Parse(input[1]);


                            try
                            {
                                names.Insert(position, input[2]);
                                result.AppendLine("OK");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                result.AppendLine("Error");
                                break;
                            }

                            if (!namesCounter.ContainsKey(input[2]))
                            {
                                namesCounter.Add(input[2], 1);
                            }
                            else
                            {
                                namesCounter[input[2]]++;
                            }

                            break;
                            
                        }

                    case "Find":
                        {
                            string name = input[1];

                            if (namesCounter.ContainsKey(input[1]))
                            {
                                result.AppendLine(namesCounter[input[1]].ToString());
                            }
                            else
                            {
                                result.AppendLine("0");
                            }
                            break;
                        }

                    case "Serve":
                        {
                            int count = int.Parse(input[1]);

                            if (count > names.Count)
                            {
                                result.AppendLine("Error");
                                break;
                            }

                           var l = names.Range(0, count);
                            StringBuilder k = new StringBuilder();

                            for(var p=0;p<l.Count;p++)
                            {
                                var o = l[p];
                                k.Append(o).Append(' ');
                                namesCounter[o]--;
                            }

                            result.AppendLine(k.ToString().Trim(' '));

                            names.RemoveRange(0,count);

                            break;;
                        }
                }

                input = Console.ReadLine().Split(' ');
            }

            Console.WriteLine(result);
        }
    }
}
