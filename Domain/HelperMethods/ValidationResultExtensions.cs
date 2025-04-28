using Application.Validators;
using FluentValidation.Results;

namespace Domain.HelperMethods
{
    public static class ValidationResultExtensions
    {
        public static ValidationResult<T> ToResult<T>(this ValidationResult validationResult) where T : class
        {
            if (validationResult.IsValid)
                return ValidationResult<T>.Success();

            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            return ValidationResult<T>.Failure(errors);
        }
    }
}
