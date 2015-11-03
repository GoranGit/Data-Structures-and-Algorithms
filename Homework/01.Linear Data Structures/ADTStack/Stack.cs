namespace ADTStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;
        private const int DeltaSize = 4;
        private T[] items;
        private int size;

        public Stack()
        {
            this.items = new T[InitialSize];
            this.Count = 0;
        }

        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.size;
            }

            private set
            {
                this.size = value;
            }
        }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.items = this.ResizeArray();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentOutOfRangeException("The stack is empty");
            }

            this.Count--;
            var item = this.items[this.Count];
            this.items[this.Count] = default(T);
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (i < this.Count)
            {
                yield return this.items[i];
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T[] ResizeArray()
        {
            var newArray = new T[this.Capacity + DeltaSize];
            for (var i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            return newArray;
        }
    }
}
