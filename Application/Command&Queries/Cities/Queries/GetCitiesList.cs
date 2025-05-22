using Application.DataTransferObjects;
using Application.Validators;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;
using Domain.Services.Validation;

namespace Application.Cities.Queries;
public class GetCitiesList
{
    public class Query : IRequest<OperationResult<List<BasicListDTO>>> { }

    public class Handler(IRepositoty<City> cityRepositoty) : IRequestHandler<Query, OperationResult<List<BasicListDTO>>>
    {
        public async Task<OperationResult<List<BasicListDTO>>> Handle(Query request, CancellationToken cancellationToken = default)
        {
            var cities = await cityRepositoty.GetAll(cancellationToken);
            return new OperationResult<List<BasicListDTO>>()
            {
                Data = cities.Data.Select(c => new BasicListDTO()
                {
                    Id = c.Id.ToString(),
                    Name = c.CityName,
                }).ToList(),
                Message = cities.Message,
                ExceptionDetails = cities.ExceptionDetails,
                StatusCode = cities.StatusCode,
            };
        }
    }
}


