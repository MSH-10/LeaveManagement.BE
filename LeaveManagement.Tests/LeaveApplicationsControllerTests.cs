using AutoMapper;
using LeaveManagement.Core.Controllers;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using LeaveManagement.Core.Interfaces;
using LeaveManagement.Core.Mappings;
using LeaveManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LeaveManagement.Tests.Controllers
{
    public class LeaveApplicationsControllerTests
    {
        private readonly LeaveApplicationsController _controller;
        private readonly Mock<ILeaveApplicationService> _mockService;
        private readonly IMapper _mapper;

        public LeaveApplicationsControllerTests()
        {
            _mockService = new Mock<ILeaveApplicationService>();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            }).CreateMapper();

            _controller = new LeaveApplicationsController(_mockService.Object, _mapper);
        }

        [Fact]
        public async Task GetAllLeaveApplications_ReturnsOkResult()
        {
            // Arrange
            var leaveApplications = GetTestLeaveApplications();
            _mockService.Setup(repo => repo.GetAllLeaveApplicationsAsync()).ReturnsAsync(leaveApplications);

            // Act
            var result = await _controller.GetAllLeaveApplications();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<LeaveApplicationDto>>(okResult.Value);
            Assert.Equal(3, model.Count()); // Assuming we expect 3 leave applications
        }

        [Fact]
        public async Task GetLeaveApplicationById_ReturnsOkResult()
        {
            // Arrange
            var leaveApplication = new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() };
            _mockService.Setup(repo => repo.GetLeaveApplicationByIdAsync(It.IsAny<Guid>())).ReturnsAsync(leaveApplication);

            // Act
            var result = await _controller.GetLeaveApplicationById(Guid.NewGuid());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<LeaveApplicationDto>(okResult.Value);
            Assert.Equal(leaveApplication.Id, model.Id);
        }

        [Fact]
        public async Task AddLeaveApplication_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var leaveApplicationDto = new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() };

            // Act
            var result = await _controller.AddLeaveApplication(leaveApplicationDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsAssignableFrom<LeaveApplicationDto>(createdAtActionResult.Value);
            Assert.Equal(leaveApplicationDto.Id, model.Id);
        }

        [Fact]
        public async Task UpdateLeaveApplication_ReturnsNoContentResult()
        {
            // Arrange
            var leaveApplicationDto = new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() };

            // Act
            var result = await _controller.UpdateLeaveApplication(Guid.NewGuid(), leaveApplicationDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteLeaveApplication_ReturnsNoContentResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _controller.DeleteLeaveApplication(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        private IEnumerable<LeaveApplicationDto> GetTestLeaveApplications()
        {
            return new List<LeaveApplicationDto>
            {
                new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() },
                new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() },
                new LeaveApplicationDto { Id = Guid.NewGuid(), ApplicantUserId = Guid.NewGuid(), ManagerId = Guid.NewGuid() }
            };
        }
    }
}
