using System;
using System.Collections;
using System.Collections.Generic;

namespace _03_stack
{
    public class Stack<T> : IEnumerable<T>
    {
        public Stack(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public Stack()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public void Push(params T[] items)
        {
            this.Push(items);
        }

        public void Push(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }

        public T Pop()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var lastIndex = this.Items.Count - 1;
            var item = this.Items[lastIndex];
            this.Items.RemoveAt(lastIndex);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}