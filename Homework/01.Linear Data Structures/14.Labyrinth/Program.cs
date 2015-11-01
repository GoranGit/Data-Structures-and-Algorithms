namespace _14.Labyrinth
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            //Test labyrinth
            char[,] labyrinth =
                                 {
                {'0', '0', '0', 'x', '0', 'x'},
                {'0', 'x', '0', 'x', '0', 'x'},
                {'0', '*', 'x', '0', 'x', '0'},
                {'0', 'x', '0', '0', '0', '0'},
                {'0', '0', '0', 'x', 'x', '0'},
                {'0', '0', '0', 'x', '0', 'x'}
            };

            Position player = new Position { Row = 2, Column = 1 };
            int[,] resultMoves = new int[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            Queue<QueueItem> queue = new Queue<QueueItem>();

            HashSet<Position> visited = new HashSet<Position>();

            queue.Enqueue(new QueueItem { Position = player, Value = 0 });
            visited.Add(player);

            while (queue.Count != 0)
            {
                var cell = queue.Dequeue();

                if (OutOfField(cell.Position, labyrinth))
                {
                    continue;
                }

                Position up = new Position { Row = cell.Position.Row - 1, Column = cell.Position.Column };
                Position down = new Position { Row = cell.Position.Row + 1, Column = cell.Position.Column };
                Position left = new Position { Column = cell.Position.Column - 1, Row = cell.Position.Row };
                Position right = new Position { Column = cell.Position.Column + 1, Row = cell.Position.Row };

                VisiteCell(labyrinth, up, visited, cell.Value + 1, queue, resultMoves);
                VisiteCell(labyrinth, down, visited, cell.Value + 1, queue, resultMoves);
                VisiteCell(labyrinth, left, visited, cell.Value + 1, queue, resultMoves);
                VisiteCell(labyrinth, right, visited, cell.Value + 1, queue, resultMoves);
            }

            char[,] resultLabyrinth = new char[labyrinth.GetLength(0), labyrinth.GetLength(1)];

            //Print the result
            for (var i = 0; i < resultMoves.GetLength(0); i++)
            {
                for (var j = 0; j < resultMoves.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == 'x')
                    {
                        Console.Write(" X ");
                    }
                    else
                        if (labyrinth[i, j] == '*')
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        if (resultMoves[i, j] == 0)
                        {
                            Console.Write(" U ");
                        }
                        else
                        {
                            Console.Write(" " + resultMoves[i, j] + " ");
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        private static void VisiteCell(char[,] labyrinth, Position visiteCellAtPosition, HashSet<Position> visited, int cellValue, Queue<QueueItem> queue, int[,] resultMovesCount)
        {
            if (!OutOfField(visiteCellAtPosition, labyrinth)
                    && labyrinth[visiteCellAtPosition.Row, visiteCellAtPosition.Column] != 'x'
                    && !visited.Contains(visiteCellAtPosition))
            {
                queue.Enqueue(new QueueItem { Position = visiteCellAtPosition, Value = cellValue });
                resultMovesCount[visiteCellAtPosition.Row, visiteCellAtPosition.Column] = cellValue;
                visited.Add(visiteCellAtPosition);
            }
        }

        private static bool OutOfField(Position cellPosition, char[,] labyrinth)
        {
            if (cellPosition.Column < 0 ||
                cellPosition.Column > labyrinth.GetLength(1) - 1 ||
                cellPosition.Row < 0 ||
                cellPosition.Row > labyrinth.GetLength(0) - 1)
            {
                return true;
            }

            return false;
        }
    }
}
