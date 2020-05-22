namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    public class EntityValidator
    {
        public static bool EntityIsValid(object movie)
        {
            try
            {
                var validationContext = new ValidationContext(movie);

                Validator.ValidateObject(movie, validationContext, true);
            }
            catch (ValidationException)
            {
                return false;
            }

            return true;
        }
    }
}