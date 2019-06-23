namespace _08_threeuple
{
    public class Threeuple<T, K, G>
    {
        public T Item1 { get; set; }

        public K Item2 { get; set; }

        public G Item3 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}