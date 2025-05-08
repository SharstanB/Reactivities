using Application.DataTransferObjects;
using Application.Validators;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;


namespace Application.Categories.Queries;
public class GetCategoriesList
{
    public class Query : IRequest<OperationResult<List<BasicListDTO>>> { }

    public class Handler(IRepositoty<Category> cityRepositoty) : IRequestHandler<Query, OperationResult<List<BasicListDTO>>>
    {
        public async Task<OperationResult<List<BasicListDTO>>> Handle(Query request, CancellationToken cancellationToken = default)
        {
            var cities = await cityRepositoty.GetAll(cancellationToken);
            return new OperationResult<List<BasicListDTO>>()
            {
                Data = cities.Data.Select(c => new BasicListDTO()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                }).ToList(),
                Message = cities.Message,
                Exception = cities.Exception,
                StatusCode = cities.StatusCode,
            };
        }
    }
}


