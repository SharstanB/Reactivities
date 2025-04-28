using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public  class ValidationResult<T> where T : class
    {
        public bool IsSuccess { get; }
        public string Error { get; }

        public Statuses status { get; set; }

        private ValidationResult(bool isSuccess ,string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static ValidationResult<T> Success() => new ValidationResult<T>(true,"");
        public static ValidationResult<T> Failure(string error) => new ValidationResult<T>(false, error);
    }
}
