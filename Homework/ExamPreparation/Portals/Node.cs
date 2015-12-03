namespace Portals
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Node :  IEqualityComparer<Node>
    {
        public Node(int x, int y)
        {
            this.Childs = new HashSet<Edge>();
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }

        public int y { get; set; }

        public ICollection<Edge> Childs{ get; set; }



        public bool Equals(Node x, Node y)
        {
            if ((x.x == y.x) && (x.y == y.y))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode(this);
        }

        public int GetHashCode(Node obj)
        {
            return obj.x * 10 + obj.y;
        }
    }
}
