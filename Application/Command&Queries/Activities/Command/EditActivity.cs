using Application.DataTransferObjects.Activity;

//using Application.Mediator;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;


namespace Application.Activities.Command
{
    public class EditActivity
    {
        public class Command : IRequest<string>
        {
            public required EditActivityDTO Activity { get; set; }
        }
        public class Handler(IRepositoty<Activity> activityRepositoty) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command command, CancellationToken cancellationToken = default)
            {
                var Activity = new Activity()
                {
                    CityId = command.Activity.CityId,
                    Venue = command.Activity.Venue,
                    Latitude = command.Activity.Latitude,
                    Longitude = command.Activity.Longitude,
                    CategoryId = command.Activity.CategoryId,
                    Description = command.Activity.Description,
                    Title = command.Activity.Title,
                    Date = command.Activity.Date,
                    Id = command.Activity.Id,
                };
                await activityRepositoty.Edit(Activity, cancellationToken);
                return Activity.Id.ToString();
            }
        }
    }
}
