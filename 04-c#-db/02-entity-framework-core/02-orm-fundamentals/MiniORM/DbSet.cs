namespace MiniORM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DbSet<T> : ICollection<T>
        where T : class, new()
    {
        internal DbSet(IEnumerable<T> entities)
        {
            this.Entities = entities.ToList();


            this.ChangeTracker = new ChangeTracker<T>(entities);
        }

        internal ChangeTracker<T> ChangeTracker { get; set; }

        internal IList<T> Entities { get; set; }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity);
            }
        }

        public bool Contains(T item)
        {
            return this.Entities.Contains(item);
        }

        public void CopyTo(T[] array, int index)
        {
            this.Entities.CopyTo(array, index);
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            var removedSuccessfully = this.Entities.Remove(item);

            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }

            return removedSuccessfully;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            // INFO: Why did it have .ToArray() ?
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}