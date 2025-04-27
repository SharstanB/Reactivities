using Application.DataTransferObjects;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;

namespace Application.Activities.Queries
{
    public class GetActivityDetails
    {
        public class Query : IRequest<GetActivitiesDTO>
        {
            public Guid Id { get; set; }
        }

        public class Hanlder (IRepositoty<Activity> activityRepositoty) : IRequestHandler<Query, GetActivitiesDTO>
        {
            public async Task<GetActivitiesDTO> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var result = await activityRepositoty.GetById(request.Id, cancellationToken);
                var Activity = new GetActivitiesDTO()
                {
                    CityId = result.CityId.ToString(),
                    CityName = result.City.CityName,
                    CategoryName = result.Category.Name,
                    Date = result.Date,
                    Description = result.Description,
                    Id = result.Id.ToString(),
                    Title = result.Title,
                    CategoryId = result.CategoryId.ToString(),
                    Venue = result.Venue,
                    Latitude = result.Latitude,
                    Longitude = result.Longitude,
                };
                return Activity;
            }
        }
    }
}
