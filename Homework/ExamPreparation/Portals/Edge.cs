namespace Portals
{
    public class Edge
    {
        public Edge(int value, Node child)
        {
            this.Value = value;
            this.Child = child;
        }

        public int Value { get; set; }

        public Node Child { get; set; }

    }
}