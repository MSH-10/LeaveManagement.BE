using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Entities
{
    public interface ITrackableEntities
    {
        DateTime? CreatedDateTime { get; set; }

        Guid? CreatedUserId { get; set; }

        DateTime? ModifiedDateTime { get; set; }

        Guid? ModifiedUserId { get; set; }
    }
}
