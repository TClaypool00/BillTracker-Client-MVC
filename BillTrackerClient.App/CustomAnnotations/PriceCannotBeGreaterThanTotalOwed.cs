using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.CustomAnnotations
{
    public class PriceCannotBeGreaterThanTotalOwed : ValidationAttribute
    {
        #region Constructors
        public PriceCannotBeGreaterThanTotalOwed() : base()
        {

        }
        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double price = 0;

            if (value is double)
            {
               price = Convert.ToDouble(value);
            }
            else if (value is double userInput)
            {
                userInput = price;
            }
            else
            {
                throw new ArgumentException("Value must be a decimal or a whole number type");
            }

            var property = validationContext.ObjectType.GetProperty("TotalAmountOwed");

            if (property is null)
            {
                throw new Exception("Property does not exist");
            }

            double totalAmountDue = (double)property.GetValue(validationContext.ObjectInstance);

            if (price > totalAmountDue)
            {
                return new ValidationResult("Price cannot be greater than total amount owed");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
