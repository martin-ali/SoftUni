namespace _03_shopping_spree
{
    using System;

    public class Validator
    {
        public static void ThrowIfNameIsInvalid(string name)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void ThrowIfMoneyIsInvalid(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}