using Application.DataTransferObjects;
//using Application.Mediator;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;

namespace Application.Activities.Queries
{
    public class GetActivitiesList
    {

        public class Query : IRequest<List<GetActivitiesDTO>> {}

        public class Handler(IRepositoty<Activity> activityRepositoty) :IRequestHandler<Query, List<GetActivitiesDTO>>
        {
            public async Task<List<GetActivitiesDTO>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var activities = (await activityRepositoty.GetAll(cancellationToken)
                  ).Select(activity => new GetActivitiesDTO()
                  {
                      CityId = activity.CityId.ToString(),
                      CityName = activity.City.CityName,
                      CategoryName = activity.Category.Name,
                      CategoryId = activity.CategoryId.ToString(),
                      Date = activity.Date,
                      Description = activity.Description,
                      Id = activity.Id.ToString(),
                      Title = activity.Title,
                      Venue = activity.Venue,
                      Latitude = activity.Latitude,
                      Longitude = activity.Longitude,
                  }).ToList();

                return activities;
            }
        }
    }
}
