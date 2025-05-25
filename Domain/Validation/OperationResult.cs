using Domain.Enums;


namespace Domain.Validators
{
    public class OperationResult<T> 
    {
        public T? Data { get; set; }

        public string? Message { get; set; }

        public Statuses StatusCode { get;  set; }

        public Exception Exception { get; set; }
        public bool IsSuccess() => (StatusCode == Statuses.Success || StatusCode == Statuses.Exist);


        //private Statuses _status;
        //public Statuses Status
        //{
        //    get => _status;
        //    set
        //    {
        //        _status = value;
        //        StatusCode =(int)_status;
        //    }
        //}
        //public void Success() => IsSuccess = Statuses.Success;
        //public void Failure() => Statuses
    }
  
}
