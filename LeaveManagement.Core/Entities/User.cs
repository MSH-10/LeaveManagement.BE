using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Entities
{
    public class User : BaseEntities, ITrackableEntities
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Guid? ManagerId { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid? CreatedUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid? ModifiedUserId { get; set; }


        // Navigation property
        public ICollection<LeaveApplication>? LeaveApplications { get; set; }
    }
}
