using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.CustomeAttributes
{ 
    public class ManagerUserValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var leaveApplicationDto = (LeaveApplicationDto)validationContext.ObjectInstance;

            if (leaveApplicationDto.ManagerId == leaveApplicationDto.ApplicantUserId)
            {
                return new ValidationResult("Manager and User cannot be the same.");
            }

            return ValidationResult.Success;
        }
    }
}
