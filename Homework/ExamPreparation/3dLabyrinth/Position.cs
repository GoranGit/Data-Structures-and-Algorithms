//namespace _3dLabyrinth
//{
//    using System.CodeDom;
//    using System.Collections.Generic;
//    using System.Data;

//    public class Position : IEqualityComparer<Position>
//    {
//        public Position()
//            :this(-1,-1,-1,0)
//        {
//        }

//        public Position(int level, int row, int col, int distance)
//        {
//            this.Col = col;
//            this.Row = row;
//            this.Level = level;
//            this.Distance = distance;
//        }

//        public int Level { get; set; }

//        public int Row { get; set; }

//        public int Col { get; set; }

//        public int Distance { get; set; }

//        public bool Equals(Position x, Position y)
//        {
//            return x.GetHashCode() == y.GetHashCode();
//        }

//        public int GetHashCode(Position obj)
//        {
//            return (obj.Level * 100) + (obj.Row * 10) + (obj.Col);
//        }
//    }
//}
