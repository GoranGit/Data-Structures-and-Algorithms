namespace _14.Labyrinth
{
    using System;

    public class Position : IEquatable<Position>
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public override int GetHashCode()
        {
            return Row.GetHashCode()+Column.GetHashCode();
        }

        public bool Equals(Position other)
        {
            return this.Row.Equals(other.Row) && this.Column.Equals(other.Column);
        }
    }
}