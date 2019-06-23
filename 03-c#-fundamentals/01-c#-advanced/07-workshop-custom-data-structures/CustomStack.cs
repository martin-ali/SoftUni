using System;
using System.Collections;
using System.Collections.Generic;

namespace create_custom_data_structures
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] items = new T[InitialCapacity];

        public int Count { get; private set; } = 0;

        private void ThrowIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void ExpandArray()
        {
            var oldItems = this.items;
            var newItems = new T[this.items.Length * 2];

            for (int i = 0; i < oldItems.Length; i++)
            {
                newItems[i] = oldItems[i];
            }

            this.items = newItems;
        }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.ExpandArray();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.ThrowIfEmpty();

            this.Count--;
            // this.items[this.Count] = default(T);

            return this.items[this.Count];
        }

        public T Peek()
        {
            this.ThrowIfEmpty();

            return this.items[this.Count - 1];
        }

        public bool Contains(T item)
        {
            foreach (var current in this)
            {
                if (current.Equals(item)) return true;
            }

            return false;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in this)
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}