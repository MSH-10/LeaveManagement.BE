using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Interfaces;
using AutoMapper;
using LeaveManagement.Core.Services;

namespace LeaveManagement.Core.Controllers
{
    [Route("api/v1/leaveapplications")]
    [ApiController]
    public class LeaveApplicationsController : ControllerBase
    {
        private readonly ILeaveApplicationService _leaveApplicationService;
        private readonly IMapper _mapper;

        public LeaveApplicationsController(ILeaveApplicationService leaveApplicationService, IMapper mapper)
        {
            _leaveApplicationService = leaveApplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveApplicationDto>>> GetAllLeaveApplications()
        {
            var leaveApplications = await _leaveApplicationService.GetAllLeaveApplicationsAsync();
            return Ok(leaveApplications);
        }

        // GET: api/leaveapplications/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LeaveApplicationDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<LeaveApplicationDto>> GetLeaveApplicationById(Guid id)
        {
            var leaveApplication = await _leaveApplicationService.GetLeaveApplicationByIdAsync(id);
            if (leaveApplication == null)
            {
                return NotFound();
            }

            return Ok(leaveApplication);
        }

        // POST: api/leaveapplications
        [HttpPost]
        [ProducesResponseType(typeof(LeaveApplicationDto), 201)]
        public async Task<IActionResult> AddLeaveApplication(LeaveApplicationDto leaveApplicationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _leaveApplicationService.AddLeaveApplicationAsync(leaveApplicationDto);
            return CreatedAtAction(nameof(GetLeaveApplicationById), new { id = leaveApplicationDto.Id }, leaveApplicationDto);
        }

        // PUT: api/leaveapplications/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateLeaveApplication(Guid id, LeaveApplicationDto leaveApplicationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _leaveApplicationService.UpdateLeaveApplicationAsync(id, leaveApplicationDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/leaveapplications/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLeaveApplication(Guid id)
        {
            try
            {
                await _leaveApplicationService.DeleteLeaveApplicationAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
