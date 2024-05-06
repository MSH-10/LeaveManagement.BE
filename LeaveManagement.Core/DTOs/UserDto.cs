using LeaveManagement.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Core.DTOs
{
    public class UserDto : BaseEntitiesDto, ITrackableEntities
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        public Guid? ManagerId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedUserId { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public Guid? ModifiedUserId { get; set; }


        // Navigation property
        public ICollection<LeaveApplication>? LeaveApplications { get; set; }
    }
}
