namespace Portals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        //l-r-u-d
        public static int[] DeltaX = { -1, 1, 0, 0 };

        public static int[] DeltaY = { 0, 0, 1, -1 };

        public static void Main()
        {
            int[] playerPosition = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = playerPosition[0];
            int y = playerPosition[1];

            int[] matrixDim = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixDim[0];
            int cols = matrixDim[1];

            string[,] matrix = new string[matrixDim[0], matrixDim[1]];


            for (var i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ');

                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            Dictionary<long, Node> graph = new Dictionary<long, Node>();

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    int val = 0;
                    if (int.TryParse(matrix[i, j], out val))
                    {
                        for (var k = 0; k < 4; k++)
                        {
                            var o = i + val * DeltaY[k];
                            var p = j + val * DeltaX[k];

                            if ((o > -1) &&
                                (o < rows) &&
                                (p > -1) &&
                                (p < cols) &&
                                (matrix[o, p] != "#"))
                            {
                                var currentNode = new Node(i, j);
                                var childNode = new Node(o, p);
                                if (!graph.ContainsKey(currentNode.GetHashCode()))
                                {
                                    graph[currentNode.GetHashCode()] = currentNode;
                                }
                                else
                                {
                                    currentNode = graph[currentNode.GetHashCode()];
                                }

                                if (!graph.ContainsKey(childNode.GetHashCode()))
                                {
                                    graph[childNode.GetHashCode()] = childNode;
                                }
                                else
                                {
                                    childNode = graph[childNode.GetHashCode()];
                                }

                                Edge edge = new Edge(val, childNode);

                                currentNode.Childs.Add(edge);
                            }
                        }
                    }
                }
            }

            Node startNode = new Node(x, y);
            var result = MaxSum(graph[startNode.GetHashCode()], new Dictionary<long, Node>(),matrix);

            Console.WriteLine(result);

        }

        public static int MaxSum(Node from, Dictionary<long, Node> visited, string[,] matrix )
        {
            var sum = 0;
            var maxSum = 0;

            if (from.Childs.Count == 0)
            {
                return 0;
            }

            if (from.Childs.All(x => visited.ContainsKey(x.Child.GetHashCode())))
            {
                return int.Parse(matrix[from.x, from.y]);
            }

            visited.Add(from.GetHashCode(), from);

            foreach (var childEdge in from.Childs)
            {
                if (visited.ContainsKey(childEdge.Child.GetHashCode()))
                {
                    continue;
                }

                sum = MaxSum(childEdge.Child, visited,matrix) + childEdge.Value;

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                sum = 0;
            }

            return maxSum;
        }
    }
}
