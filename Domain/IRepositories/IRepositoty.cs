using Domain.Entities;
using Domain.Services.Validation;

namespace Domain.IRepositories
{
    //public interface IActivityRepositoty
    //{
    //    Task<List<Activity>> GetActivities(CancellationToken cancellationToken);
    //    Task<Activity?> GetActivity(Guid id ,CancellationToken cancellationToken);
    //    Task<Guid> AddActivity(Activity activity , CancellationToken cancellationToken);
    //    Task<Guid?> EditActivity(Activity activity , CancellationToken cancellationToken);
    //}

    public interface IRepositoty<TEntity> where TEntity : class
    {
        Task<OperationResult<List<TEntity>>> GetAll(CancellationToken cancellationToken);
        Task<OperationResult<TEntity?>> GetById(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<Activity>> GetByIdTest(Guid id, CancellationToken cancellationToken);
        Task<OperationResult<Guid>> Add(TEntity entity, CancellationToken cancellationToken);
        Task<OperationResult<Guid>> Edit(TEntity entity, CancellationToken cancellationToken);
        Task<OperationResult<TEntity>>Delete(Guid id, CancellationToken cancellationToken);
    }   
   
}
