using Domain.Entities;


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
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);
        Task<Guid> Add(TEntity entity, CancellationToken cancellationToken);
        Task<Guid?> Edit(TEntity entity, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }   
   
}
