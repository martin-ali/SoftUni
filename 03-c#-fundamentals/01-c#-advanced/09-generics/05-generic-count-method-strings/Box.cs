using System;

namespace _05_generic_count_method_strings
{
    public class Box<T> where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            var type = this.Value.GetType();

            return $"{type}: {this.Value}";
        }

        public int CompareTo(Box<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}