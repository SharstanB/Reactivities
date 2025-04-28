using Application.Validators;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class ActivityRepository(AppDBContext appDBContext) : IRepositoty<Activity>
    {
        public async Task<Guid> Add(Activity activity, CancellationToken cancellationToken)
        {
            appDBContext.Activities.Add(activity); // review why to not use AddAsync

            await appDBContext.SaveChangesAsync(cancellationToken);

            return activity.Id;
        }


        public async Task<Guid?> Edit(Activity activity, CancellationToken cancellationToken)
        {
            var activityToEdit = await appDBContext.Activities.FirstOrDefaultAsync(act => act.Id == activity.Id);

            if (activityToEdit == null) return null;
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

            await appDBContext.SaveChangesAsync(cancellationToken);
            return activityToEdit.Id;
        }
        public async Task<List<Activity>> GetAll(CancellationToken cancellationToken)
        {
            var activities = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .Where(activity => !activity.DeletedAt.HasValue)
                .OrderBy(activity => activity.CreatedAt)
                .ToListAsync(cancellationToken);

            return activities;

        }
        public  async Task<Activity?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var activity = await appDBContext.Activities.Include(a => a.City).Include(a => a.Category)
                .FirstOrDefaultAsync(act => act.Id == id);

            return activity;
        }


        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
           var deletedActivity =  await appDBContext.Activities.FirstOrDefaultAsync(act => act.Id == id);
            if (deletedActivity == null) return;
            deletedActivity.DeletedAt = DateTime.UtcNow;
            appDBContext.Update(deletedActivity);
            await appDBContext.SaveChangesAsync();
            
        }
   

        public ValidationResult<Task<Activity?>> GetByIdTest(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
