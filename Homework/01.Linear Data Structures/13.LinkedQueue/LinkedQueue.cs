namespace _13.LinkedQueue
{
    using System.Collections.Generic;

    public class LinkedQueue<T>
    {
        private LinkedList<T> items;
        private int size;

        public LinkedQueue()
        {
            this.items = new LinkedList<T>();
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                this.items.AddFirst(item);
            }
            else
            {
                this.items.AddAfter(this.items.Last, item);
            }

            this.Count++;
        }

        public T Dequeue()
        {
            T item;
            item = this.items.First.Value;
            this.items.Remove(item);
            this.Count--;
            return item;
        }
    }
}
