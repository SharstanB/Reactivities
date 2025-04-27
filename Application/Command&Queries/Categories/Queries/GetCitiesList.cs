using Application.DataTransferObjects;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;


namespace Application.Categories.Queries;
    public class GetCategoriesList
    {
        public class Query : IRequest<List<BasicListDTO>> { }

        public class Handler(IRepositoty<Category> cityRepositoty) : IRequestHandler<Query, List<BasicListDTO>>
        {
            public async Task<List<BasicListDTO>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var cities = (await cityRepositoty.GetAll(cancellationToken)).Select(c => new BasicListDTO()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                }).ToList();
                return cities;
            }
        }
    }

    
