using Application.Activities.Command;
using Application.DataTransferObjects.Activity;

namespace Application.Validators.Activities
{
    public class CreateActivityValidator : BaseActivityValidator<CreateActivity.Command, CreateActivityDTO>
    {
        public CreateActivityValidator() : base(x => x.Activity)
        {
        }
    }
}
