namespace _07_tuple
{
    public class Tuple<T, K>
    {
        public T Item1 { get; set; }

        public K Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}