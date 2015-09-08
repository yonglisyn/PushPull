using System;
using System.ComponentModel.DataAnnotations;

namespace PushPull.Models
{
    public class DateLargerThanTodayAttribute : ValidationAttribute
    {
        private readonly DateTime _Today = DateTime.Today;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((DateTime)value < _Today)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}