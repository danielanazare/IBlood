using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBlood002.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var donor = (Donor) validationContext.ObjectInstance;
            if (donor.BirthDate == DateTime.MinValue)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - donor.BirthDate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You should be at least 18 years old to donate.");


        }
    }
}