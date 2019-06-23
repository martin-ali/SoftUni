using System;
using System.Collections;
using System.Collections.Generic;

namespace create_custom_data_structures
{
    public class CustomList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 2;

        private T[] items = new T[InitialCapacity];

        public int Count { get; private set; }

        private void ThrowIfIndexIsOutOfRange(int index)
        {
            var indexIsValid = (0 <= index && index < this.Count);
            if (indexIsValid == false)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ResizeIfTooSMall()
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            var resizedItems = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                resizedItems[i] = this.items[i];
            }

            this.items = resizedItems;
        }

        private void Shrink()
        {
            var resizedItems = new T[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                resizedItems[i] = this.items[i];
            }

            this.items = resizedItems;
        }

        private void Shift(int index)
        {
            for (int current = index; current < this.Count - 1; current++)
            {
                this.items[current] = this.items[current + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int current = this.Count; current > index; current--)
            {
                this.items[current] = this.items[current - 1];
            }
        }

        public void Add(T item)
        {
            this.ResizeIfTooSMall();

            this.items[this.Count] = item;
            this.Count++;
        }

        public void Insert(int index, T item)
        {
            var indexIsValid = (0 <= index && index <= this.Count);
            if (indexIsValid == false)
            {
                throw new IndexOutOfRangeException();
            }

            this.ShiftToRight(index);

            this.items[index] = item;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            this.ThrowIfIndexIsOutOfRange(index);

            var removedItem = this.items[index];
            this.items[index] = default(T);

            Shift(index);
            this.Count--;

            if (Count <= (this.items.Length / 4))
            {
                this.Shrink();
            }

            return removedItem;
        }

        public bool Contains(T item)
        {
            foreach (var current in this)
            {
                if (current.Equals(item)) return true;
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ThrowIfIndexIsOutOfRange(firstIndex);
            this.ThrowIfIndexIsOutOfRange(secondIndex);

            var firstItem = this.items[firstIndex];
            var secondItem = this.items[secondIndex];

            this.items[firstIndex] = secondItem;
            this.items[secondIndex] = firstItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                this.ThrowIfIndexIsOutOfRange(index);

                return this.items[index];
            }
            set
            {
                this.ThrowIfIndexIsOutOfRange(index);

                this.items[index] = value;
            }
        }
    }
}