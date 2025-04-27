using Domain.IRepositories;
using Domain.Entities;
using Application.DataTransferObjects;
using Domain.Mediator;
namespace Application.Activities.Command
{
    public class CreateActivity
    {
        public class Command : IRequest<string>
        {
           public required  CreateActivityDTO Activity { get; set; }

        }

        public class Handler (IRepositoty<Activity> activityRepositoty) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken = default)
            {
                var Activity = new Activity()
                {
                    CityId = request.Activity.CityId,
                    Venue = request.Activity.Venue,
                    Latitude = request.Activity.Latitude,
                    Longitude = request.Activity.Longitude,
                    CategoryId = request.Activity.CategoryId,
                    Description = request.Activity.Description,
                    Title = request.Activity.Title,
                    Date = request.Activity.Date.ToUniversalTime(),
                };
                var newActivityId = await activityRepositoty.Add(Activity, cancellationToken);

                return newActivityId.ToString();
            }

        }
    }
}
