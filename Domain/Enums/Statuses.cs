using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Statuses
    {
        UnKnown,
        Success,
        Exist,
        NotExist,
        Failed,
        Forbidden,
        Exception, 
        Unauthorized
    }
}
