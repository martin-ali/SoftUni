namespace _03_generic_swap_method_strings
{
    public class Box<T>
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
    }
}