using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.DTOs
{
    public class TrackableEntitiesDto
    {
        DateTime? CreatedDateTime { get; set; }

        Guid? CreatedUserId { get; set; }

        DateTime? ModifiedDateTime { get; set; }

        Guid? ModifiedUserId { get; set; }
    }
}
