namespace _3dLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Position
    {
        public Position(sbyte level, sbyte row, sbyte col, int distance)
        {
            this.Col = col;
            this.Row = row;
            this.Level = level;
            this.Distance = distance;
        }

        public sbyte Level { get; set; }

        public sbyte Row { get; set; }

        public sbyte Col { get; set; }

        public int Distance { get; set; }
    }

    public class Program
    {
        public static char[, ,] matrix;

        public static Position playerPosition;

        public static bool[, ,] visited;

        //up, down,right,left,front,back
        public static sbyte[] DeltaLevel = new sbyte[] { 1, -1, 0, 0, 0, 0 };

        public static sbyte[] DeltaRow = new sbyte[] { 0, 0, 0, 0, 1, -1 };

        public static sbyte[] DeltaCol = new sbyte[] { 0, 0, -1, 1, 0, 0 };

        public static void Main()
        {

            var startPosition = Console.ReadLine().Split(' ').Select(sbyte.Parse).ToArray();
            playerPosition = new Position(startPosition[0], startPosition[1], startPosition[2], 0);

            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            matrix = new char[dimensions[0], dimensions[1], dimensions[2]];
            visited = new bool[dimensions[0], dimensions[1], dimensions[2]];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var k = 0; k < matrix.GetLength(1); k++)
                {
                    var chars = Console.ReadLine().ToCharArray();
                    for (int j = 0; j < chars.Length; j++)
                    {
                        matrix[i, k, j] = chars[j];
                    }

                }
            }

            TraverseLabyrinth();
        }

        public static void TraverseLabyrinth()
        {
            var nodes = new Queue<Position>();
            nodes.Enqueue(playerPosition);
            visited[playerPosition.Level,playerPosition.Row,playerPosition.Col] = true;

            while (nodes.Count != 0)
            {
                Position currentNode = nodes.Dequeue();
                // Console.WriteLine(currentNode);

                for (int i = 0; i < 6; i++)
                {
                    sbyte newLevel = (sbyte)(currentNode.Level + DeltaLevel[i]);
                    sbyte newRow = (sbyte)(currentNode.Row + DeltaRow[i]);
                    sbyte newCol = (sbyte)(currentNode.Col + DeltaCol[i]);

                    var neighbor = new Position(newLevel, newRow, newCol, currentNode.Distance + 1);

                    bool pathFound = PathFound(neighbor);
                    bool permited = PermitedPosition(neighbor, currentNode);

                    if (permited && (!pathFound) && (!visited[neighbor.Level,neighbor.Row,neighbor.Col]))
                    {
                        nodes.Enqueue(neighbor);
                        visited[neighbor.Level,neighbor.Row,neighbor.Col] = true;
                        continue;
                    }

                    if (permited && pathFound)
                    {
                        Console.WriteLine(neighbor.Distance);
                        return;
                    }
                }
            }
        }

        public static bool PathFound(Position final)
        {
            if (final.Level < 0 || final.Level > matrix.GetLength(0) - 1)
            {
                return true;
            }

            return false;
        }

        public static bool PermitedPosition(Position to, Position from)
        {
            if (to.Row < 0 || to.Row > matrix.GetLength(1) - 1)
            {
                return false;
            }

            if (to.Col < 0 || to.Col > matrix.GetLength(2) - 1)
            {
                return false;
            }

            if ((to.Level >= 0)
                && (to.Level <= (matrix.GetLength(0) - 1))
                && matrix[to.Level, to.Row, to.Col] == '#')
            {
                return false;
            }

            if (matrix[from.Level, from.Row, from.Col] == 'U')
            {
                if (to.Level != (from.Level + 1))
                {
                    return false;
                }
            }

            if (matrix[from.Level, from.Row, from.Col] != 'U')
            {
                if (to.Level == (from.Level + 1))
                {
                    return false;
                }
            }

            if (matrix[from.Level, from.Row, from.Col] != 'D')
            {
                if (to.Level == (from.Level - 1))
                {
                    return false;
                }
            }

            if (matrix[from.Level, from.Row, from.Col] == 'D')
            {
                if (to.Level != (from.Level - 1))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
