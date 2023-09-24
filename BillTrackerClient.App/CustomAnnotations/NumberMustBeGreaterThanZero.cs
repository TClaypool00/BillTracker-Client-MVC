using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.CustomAnnotations
{
    public class NumberMustBeGreaterThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int number)
            {
                if (number > 0)
                {
                    return true;
                }
                else
                {
                    ErrorMessage = "Must be greater than 0";

                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Must be an integer");
            }
        }
    }
}
