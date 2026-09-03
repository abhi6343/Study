using ServiceContractsxUnit.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicesxUnit.Helpers
{
    public class ValidationHelper
    {
        public static void ModelValidation(object obj)
        {
            //Model validations
            var validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = [];
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
