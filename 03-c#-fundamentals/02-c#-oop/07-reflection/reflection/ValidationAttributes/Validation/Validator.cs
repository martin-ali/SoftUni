namespace ValidationAttributes.Validation
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                var attributes = property.GetCustomAttributes<MyValidationAttribute>();

                if (attributes.Any(a => a.IsValid(value) == false))
                {
                    return false;
                }
            }

            return true;
        }
    }
}