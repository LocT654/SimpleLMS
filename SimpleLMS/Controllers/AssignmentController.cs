using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace SimpleLMSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly List<Assignment> _assignments;

        public AssignmentController()
        {
            _assignments = new List<Assignment>
            {
                new Assignment { ModuleId = 1, Id = 2, Name = "A1", Grade = 100, DueDate = DateTime.Now},
                new Assignment { ModuleId = 2, Id = 3, Name = "A2", Grade = 91, DueDate = DateTime.Now},
                new Assignment { ModuleId = 2, Id = 4, Name = "A3", Grade = 81, DueDate = DateTime.Now},
           
            };
        }

        [HttpGet("GetAssignments")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await Task.FromResult(_assignments);
        }

        [HttpGet("GetAssignment/{assignmentId}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int assignmentId)
        {
            var assignment = _assignments.FirstOrDefault(a => a.Id == assignmentId);
            return await Task.FromResult(assignment);
        }

        [HttpPost("AddAssignment")]
        public async Task<ActionResult<IEnumerable<Assignment>>> AddAssignment([FromBody] Assignment assignment)
        {
            _assignments.Add(assignment);
            return await Task.FromResult(_assignments);
        }

        [HttpPut("UpdateAssignment/{oldAssignmentId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> UpdateAssignment(int oldAssignmentId, [FromBody] Assignment newAssignment)
        {
            int index = _assignments.FindIndex(a => a.Id == oldAssignmentId);
            _assignments[index] = newAssignment;
            return await Task.FromResult(_assignments);
        }

        [HttpDelete("RemoveAssignment/{assignmentId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> RemoveAssignment(int assignmentId)
        {
            _assignments.RemoveAll(a => a.Id == assignmentId);
            return await Task.FromResult(_assignments);
        }
    }
}

