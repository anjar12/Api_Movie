using Domain.Interfaces;
using Domain.Model;
using Domain.Model.ValidatorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Repository.Validators
{
    public class ValidatorRepository : IValidators
    {
        public async Task<Tuple<bool, Result>> ValidationByID(int data)
        {
            ValidationByID dataValidation = new ValidationByID();
            dataValidation.ID = data;
            Result result = new();
            ValidationResult validation = await TransactionalValidator.GetListMovieValidator.Validate().GetListMovieModelValidator().ValidateAsync(dataValidation); ;
            if (!validation.IsValid)
            {
                string message = await FluentValidationService.CreateValidatorResult(validation);
                result = new ResultError().result(0, true, message);
                return new Tuple<bool, Result>(false, result);
            }
            else
            {
                return new Tuple<bool, Result>(true, result);
            }
        }
        public async Task<Tuple<bool, Result>> ValidationInsert(InsertMovie data)
        {
            Result result = new();
            ValidationResult validation = await TransactionalValidator.InsertMovieValidator.Validate().InsertMovieModelValidator().ValidateAsync(data); ;
            if (!validation.IsValid)
            {
                string message = await FluentValidationService.CreateValidatorResult(validation);
                result = new ResultError().result(0, true, message);
                return new Tuple<bool, Result>(false, result);
            }
            else
            {
                return new Tuple<bool, Result>(true, result);
            }
        }
    }
}
