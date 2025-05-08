using Application.HelperMethods;
using Application.Validators;
using Domain.Entities;
using Domain.Enums;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ActivityRepository(AppDBContext appDBContext) : IRepositoty<Activity>
    {
        public async Task<OperationResult<Guid>> Add(Activity activity, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();
            appDBContext.Activities.Add(activity); // review why to not use AddAsync
            result = await appDBContext.SaveDataChanges(result, cancellationToken);
            result.Data = activity.Id;
            return result;
        }


        public async Task<OperationResult<Guid>> Edit(Activity activity, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();

            var activityToEdit = await appDBContext.Activities.FirstOrDefaultAsync(act => act.Id == activity.Id);

            if (activityToEdit == null)
            {
                result.StatusCode = Statuses.NotExist;
            }
            else
            {
                activityToEdit.Description = activity.Description;
                activityToEdit.Date = activity.Date.ToUniversalTime();
                activityToEdit.Title = activity.Title;
                activityToEdit.IsCancelled = activity.IsCancelled;
                activityToEdit.Venue = activity.Venue;
                activityToEdit.Latitude = activity.Latitude;
                activityToEdit.Longitude = activity.Longitude;
                activityToEdit.Category = activity.Category;
                activityToEdit.CategoryId = activity.CategoryId;
                activityToEdit.City = activity.City;
                activityToEdit.CityId = activity.CityId;
                appDBContext.Activities.Update(activityToEdit);
                result = await appDBContext.SaveDataChanges(result, cancellationToken);
            }
               
            return result;
        }
        public async Task<OperationResult<List<Activity>>> GetAll(CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Activity>>();
            var activities = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .Where(activity => !activity.DeletedAt.HasValue)
                .OrderBy(activity => activity.CreatedAt)
                .ToListAsync(cancellationToken);
            if (activities == null) result.StatusCode = Statuses.NotExist;
            else
            {
                result.Data = activities;
                result.StatusCode = Statuses.Success;
            }
            return result;
        }
        public  async Task<OperationResult<Activity>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Activity>();
            var activity = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .FirstOrDefaultAsync(act => act.Id == id);
            if (activity == null) result.StatusCode = Statuses.NotExist;
            else
            {
                result.Data = activity;
                result.StatusCode = Statuses.Success;
            }
            return result;
        }
        public async Task<OperationResult<Activity>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Activity>();
            var activity = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .FirstOrDefaultAsync(act => act.Id == id);
            if (activity == null) result.StatusCode = Statuses.NotExist;
            else
            {
                activity.DeletedAt = DateTime.UtcNow;
                appDBContext.Activities.Update(activity);
                result = await appDBContext.SaveDataChanges(result, cancellationToken);
            }
            return result;
        }
   

        public async Task<OperationResult<Activity>> GetByIdTest(Guid id, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Activity>();

            var activity = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .FirstOrDefaultAsync(act => act.Id == id);
            if(activity == null) result.StatusCode = Statuses.NotExist;
            else
            {
                result.Data = activity;
                result.StatusCode = Statuses.Success;
            }
            return result;
        }
    }
}
