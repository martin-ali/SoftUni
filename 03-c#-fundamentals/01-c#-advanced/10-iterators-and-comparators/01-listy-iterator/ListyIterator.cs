using System;
using System.Collections.Generic;

namespace _01_listy_iterator
{
    public class ListyIterator<T>
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
    }
}