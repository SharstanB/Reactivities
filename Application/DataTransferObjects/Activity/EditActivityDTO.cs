using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Activity
{
    public class EditActivityDTO : CreateActivityDTO
    {
        public required Guid Id { get; set; }
    }
}
