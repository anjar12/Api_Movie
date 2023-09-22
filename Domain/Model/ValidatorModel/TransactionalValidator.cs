using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValidatorModel
{
    public class TransactionalValidator
    {
        public class GetListMovieValidator : AbstractValidator<ValidationByID>
        {
            public GetListMovieValidator GetListMovieModelValidator()
            {
                RuleFor(x =>x.ID).NotNull().GreaterThan(0).WithMessage("Parameters Not Allow NULL/0");
                return this;
            }
            public static GetListMovieValidator Validate()
            {
                return new GetListMovieValidator();
            }
        }
        public class InsertMovieValidator : AbstractValidator<InsertMovie>
        {
            public InsertMovieValidator InsertMovieModelValidator()
            {
                RuleFor(x => x.Title).NotNull().NotEmpty();
                RuleFor(x => x.Description).NotNull().NotEmpty();
                RuleFor(x => x.Image).NotNull();
                RuleFor(x => x.Rating).NotNull();
                RuleFor(x => x.Updated_at).NotNull();
                RuleFor(x => x.Created_at).NotNull();
                return this;
            }
            public static InsertMovieValidator Validate()
            {
                return new InsertMovieValidator();
            }
        }
    }
}
