using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CityRepository(AppDBContext appDBContext) : IRepositoty<City>
    {
        public Task<Guid> Add(City entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid?> Edit(City entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<List<City>> GetAll(CancellationToken cancellationToken)
        {
            var cities = await appDBContext.Cities.Where(city => !city.DeletedAt.HasValue)
                .ToListAsync(cancellationToken);

            return cities;
        }
        public async Task<City?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var city = await appDBContext.Cities.FirstOrDefaultAsync(act => act.Id == id);

            return city;
        }
    }
  
}
