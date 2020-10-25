using System;

namespace Git.Common
{
    public class Messages
    {
        public static string Invalid(string param) => $"{param} is invalid";

        public static string Taken(string param) => $"{param} is taken";

        public static string WrongLength(string param, int minLength, int maxLength) => $"{param} should be between {minLength} and {maxLength} characters";

        public static string LessThanAllowedValue(string param, int minAllowed) => $"{param} cannot be below {minAllowed}";

        public static string OverAllowedCharacters(string param, int maxAllowed) => $"{param} cannot be more than {maxAllowed} characters";

        public static string UnderAllowedCharacters(string param, int minAllowed) => $"{param} cannot be less than {minAllowed} characters";

        public static string DoNotMatch(string param) => $"{param} don't match";

        public static string OnlyOwnerCanDelete(string param) => $"Only an owner can delete a {param}";
    }
}