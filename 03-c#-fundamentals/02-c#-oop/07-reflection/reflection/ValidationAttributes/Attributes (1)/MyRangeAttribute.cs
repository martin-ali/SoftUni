using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            // var value = (int)obj;
            var value = Convert.ToInt32(obj);

            var valueIsValid = this.minValue <= value && value <= this.maxValue;
            return valueIsValid;
        }
    }
}