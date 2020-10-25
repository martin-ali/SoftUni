namespace BattleCards.Common
{
    public class Messages
    {
        public static string Invalid(string param) => $"{param} is invalid";

        public static string Taken(string param) => $"{param} is taken";

        public static string WrongLength(string param, int minLength, int maxLength) => $"{param} should be between {minLength} and {maxLength} characters";

        public static string LessThanAllowed(string param, int minAllowed) => $"{param} cannot be below {minAllowed}";

        public static string OverAllowed(string param, int maxAllowed) => $"{param} cannot be more than {maxAllowed} characters";
    }
}