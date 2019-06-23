using System;
using System.Collections;
using System.Collections.Generic;

namespace _02_collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int _index = 0;

        public ListyIterator(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public List<T> Items { get; private set; }

        public bool Move()
        {
            if (this._index < this.Items.Count - 1)
            {
                this._index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this._index < this.Items.Count - 1;
        }

        public string Print()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.Items[this._index].ToString();
        }

        public string PrintAll()
        {
            // return string.Join(' ', this.Items);
            var itemsSeparatedBySpace = string.Empty;
            foreach (var item in this.Items)
            {
                itemsSeparatedBySpace += $"{item} ";
            }

            return itemsSeparatedBySpace;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}