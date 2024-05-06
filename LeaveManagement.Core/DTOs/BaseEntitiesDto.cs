using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.DTOs
{
    public class BaseEntitiesDto : TrackableEntitiesDto
    {
        public Guid Id { get; set; }
    }
}
