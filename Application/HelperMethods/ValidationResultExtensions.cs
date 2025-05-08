using Application.Validators;
using Domain.Enums;
using FluentValidation.Results;
using Persistence;

namespace Application.HelperMethods
{
    public static class ValidationResultExtensions
    {
        public static async Task<OperationResult<T>> SaveDataChanges<T>(this AppDBContext context , OperationResult<T> operationResult, CancellationToken
            cancellationToken)
        {
            try
            {
                await context.SaveChangesAsync(cancellationToken);
                operationResult.StatusCode = Statuses.Success;
            }
            catch (Exception e)
            {
                operationResult.StatusCode = Statuses.Exception;
                operationResult.Message = $"There is {Statuses.Exception.ToString()} in Database, please recheck";
                operationResult.Exception = e.InnerException;
            }

            return operationResult;
        }
    }
}
