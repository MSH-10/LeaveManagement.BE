using LeaveManagement.Core.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Entities
{
    public class LeaveApplication : BaseEntities, ITrackableEntities
    {
        [ManagerUserValidator]
        public Guid ApplicantUserId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfDays { get; set; }
        public string GeneralComments { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public Guid? CreatedUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid? ModifiedUserId { get; set; }

        // Navigation property
        public User User { get; set; }

    }
}