using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; }
        public List<string> Errors { get; } = new();

        public bool IsFailure => !IsSuccess;

        private Result(bool isSuccess, List<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<string>();
        }

        public static Result<T> Success() => new Result<T>(true, new List<string>());
        public static Result<T> Failure(List<string> errors) => new Result<T>(false, errors);
    }
}
