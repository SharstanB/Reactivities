using Application.DataTransferObjects.Activity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Activities
{
    public class BaseActivityValidator<T, DTO> : AbstractValidator<T> where DTO : BaseActivityDTO
    {

        public BaseActivityValidator(Func<T, DTO> Selector)
        {

            RuleFor(x =>  Selector(x).Title ).NotEmpty().WithMessage("Activity Title most not be empty")
                    .MaximumLength(100).WithMessage("Title most not be less thab 100 characters");
            RuleFor( x =>  Selector(x).Date).GreaterThan(DateTime.UtcNow).WithMessage("Date most be in the fulture")
                    .NotEmpty().WithMessage("Date most not be empty");
            RuleFor(x => Selector(x).CityId).NotEmpty().WithMessage("CityId most not be empty");
            RuleFor(x => Selector(x).CategoryId).NotEmpty().WithMessage("CategoryId most not be empty");
            RuleFor(x => Selector(x).Description).NotEmpty().WithMessage("Description most not be empty");
            RuleFor(x => Selector(x).Venue).NotEmpty().WithMessage("Venue most not be empty");
            RuleFor(x => Selector(x).Latitude)
                    //.NotEmpty().WithMessage("Latitude most not be empty")
                    .InclusiveBetween(-90, 90).WithMessage("Latitude most be between -90 & 90");
            RuleFor(x => Selector(x).Longitude)
                    //.NotEmpty().WithMessage("Longitude most not be empty")
                    .InclusiveBetween(-180, 180).WithMessage("Longitude most be between -180 & 180");
        }
    }
}
