namespace _04_generic_swap_method_integers
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