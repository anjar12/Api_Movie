using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValidatorModel
{
    public class FluentValidationService
    {
        public static async Task<string> CreateValidatorResult(ValidationResult validationResult)
        {
            string message = string.Empty;
            foreach (var error in validationResult.Errors)
            {
                message += error.PropertyName + ',' + error.ErrorMessage + ';';
            }
            return message;
        }
    }
    public class ValidationByID
    {
        public int ID { get; set; }
    }

}
