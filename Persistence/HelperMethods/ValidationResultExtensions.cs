using Domain.Enums;
using Domain.Services.Validation;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Persistence.HelperMethods
{
    public static class ValidationResultExtensions
    {
        //public static async Task<OperationResult<T>> SaveDataChanges<T>(this IServiceProvider serviceProvider, T entity, CancellationToken
        //    cancellationToken)
        //{
        //    var operationResult = new OperationResult<T>();
        //    using var scope = serviceProvider.CreateScope();
        //    var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

        //    try
        //    {
        //        await context.SaveChangesAsync(cancellationToken);
        //        operationResult.StatusCode = Statuses.Success;
        //    }
        //    catch (Exception e)
        //    {
        //        operationResult.StatusCode = Statuses.Exception;
        //        operationResult.Message = $"There is {Statuses.Exception.ToString()} in Database, please recheck";
        //        operationResult.ExceptionDetails = e.Message;
        //    }

        //    return operationResult;
        //}
    }
}
