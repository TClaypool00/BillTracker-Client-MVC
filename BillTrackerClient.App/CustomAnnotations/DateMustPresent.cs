using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.CustomAnnotations
{
    public class DateMustPresent : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                if (date > DateTime.Today.AddMonths(-1) && date < DateTime.Today)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Value must be a DateTime");
            }
        }
    }
}
