using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int min;
        private int max;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.min = minValue;
            this.max = maxValue;
        }

        public override bool IsValid(object person)
        {
            if (!(person is int))
            {
                throw new ArgumentException();
            }

            int value = (int)person;

            if (value >= min && value<= max)
            {
                return true;
            }
            return false;
        }
    }
}
