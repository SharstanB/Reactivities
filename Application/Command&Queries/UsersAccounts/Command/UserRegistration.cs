using Application.DataTransferObjects.UsersAccounts;
using Domain.CoreServices;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Mediator;
using FluentValidation;

namespace Application.Command_Queries.UsersAccounts.Command
{
    public class UserRegistration
    {
        public class Command : IRequest<OperationResult<Guid>>
        {
            public required UserRegistrationDTO UserRegistration { get; set; }

        }

        public class Handler(IRepositoty<Activity> activityRepositoty, IValidator<Command> validator)
            : IRequestHandler<Command, OperationResult<Guid>>
        {
            public async Task<OperationResult<Guid>> Handle(Command request, CancellationToken cancellationToken = default)
            {

                //TODO  I should find a way for this garbage 
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return new OperationResult<Guid>()
                    {
                        ExceptionDetails = (new ValidationException(validationResult.Errors)).Message,
                        Message = string.Join(",", validationResult.Errors),
                        StatusCode = Statuses.Exception,
                    };
                }

                var Activity = new Activity()
                {
                    City = request.Activity.City,
                    Venue = request.Activity.Venue,
                    Latitude = request.Activity.Latitude,
                    Longitude = request.Activity.Longitude,
                    CategoryId = request.Activity.CategoryId,
                    Description = request.Activity.Description,
                    Title = request.Activity.Title,
                    Date = request.Activity.Date.ToUniversalTime(),
                };
                var result = await activityRepositoty.Add(Activity, cancellationToken);

                return result;
            }

        }
    }
}
