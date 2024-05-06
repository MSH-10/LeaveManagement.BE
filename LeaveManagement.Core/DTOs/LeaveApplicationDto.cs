using LeaveManagement.Core.CustomeAttributes;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Core.DTOs
{
    public class LeaveApplicationDto : BaseEntitiesDto, ITrackableEntities
    {
        [ManagerUserValidator]
        [Required(ErrorMessage = "Applicant User ID is required")]
        public Guid ApplicantUserId { get; set; }

        [Required(ErrorMessage = "Manager ID is required")]
        public Guid ManagerId { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Return Date is required")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Number of Days is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Days must be at least 1")]
        public int NumberOfDays { get; set; }

        [Required(ErrorMessage = "General Comments is required")]
        [MaxLength(500, ErrorMessage = "General Comments cannot exceed 500 characters")]
        public string GeneralComments { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedUserId { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public Guid? ModifiedUserId { get; set; }

        // Navigation property
        public User? User { get; set; }
    }
}
