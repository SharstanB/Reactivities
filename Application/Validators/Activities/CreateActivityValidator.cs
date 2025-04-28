using Application.Activities.Command;
using FluentValidation;

namespace Application.Validators.Activities
{
    public class CreateActivityValidator : AbstractValidator<CreateActivity.Command>
    {
        public CreateActivityValidator() { 
        
            RuleFor(x => x.Activity.Title).NotNull().WithMessage("Activity cannot be null");
            RuleFor(x => x.Activity.CityId).NotEmpty().WithMessage("CityId cannot be empty");
            RuleFor(x => x.Activity.CategoryId).NotEmpty().WithMessage("CategoryId cannot be empty");
        }
    }
}
