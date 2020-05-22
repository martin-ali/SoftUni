namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var objIsValid = obj != null;
            return objIsValid;
        }
    }
}