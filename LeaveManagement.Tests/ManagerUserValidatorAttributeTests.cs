using Xunit;
using LeaveManagement.Core.CustomeAttributes;
using LeaveManagement.Core.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Core.Tests.CustomeAttributes
{
    public class ManagerUserValidatorAttributeTests
    {
        private readonly ManagerUserValidatorAttribute _validator;

        public ManagerUserValidatorAttributeTests()
        {
            _validator = new ManagerUserValidatorAttribute();
        }

        [Fact]
        public void ManagerUserValidatorAttribute_WhenManagerIdAndApplicantUserIdAreSame_ReturnsValidationError()
        {
            // Arrange
            var leaveApplicationDto = new LeaveApplicationDto
            {
                ApplicantUserId = Guid.NewGuid(),
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(5),
                ReturnDate = DateTime.Now.Date.AddDays(6),
                NumberOfDays = 5,
                GeneralComments = "Test comments"
            };
            leaveApplicationDto.ManagerId = leaveApplicationDto.ApplicantUserId; // Set the same GUID for ManagerId and ApplicantUserId

            // Act
            var validationResult = _validator.GetValidationResult(leaveApplicationDto, new ValidationContext(leaveApplicationDto));

            // Assert
            Assert.NotNull(validationResult);
            //Assert.False(validationResult.IsValid);
            Assert.Equal("Manager and User cannot be the same.", validationResult.ErrorMessage);
        }

        [Fact]
        public void ManagerUserValidatorAttribute_WhenManagerIdAndApplicantUserIdAreDifferent_ReturnsValidationSuccess()
        {
            // Arrange
            var leaveApplicationDto = new LeaveApplicationDto
            {
                ApplicantUserId = Guid.NewGuid(),
                ManagerId = Guid.NewGuid(), // Set different GUIDs for ManagerId and ApplicantUserId
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date.AddDays(5),
                ReturnDate = DateTime.Now.Date.AddDays(6),
                NumberOfDays = 5,
                GeneralComments = "Test comments"
            };

            // Act
            var validationResult = _validator.GetValidationResult(leaveApplicationDto, new ValidationContext(leaveApplicationDto));

            // Assert
            Assert.Null(validationResult);
        }
    }
}
