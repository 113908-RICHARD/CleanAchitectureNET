using Application.DTOs.LeaveAllocation;
using Application.Features.LeaveAllocations.Requests;
using Application.Features.LeaveRequests.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var request = await _mediator.Send(new GetLeaveAllocationsListRequest());
            return Ok(request);
            
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLeaveAllocationRequest>> Get(int id)
        {
            var request = await _mediator.Send(new GetLeaveAllocationRequest { _Id = id });
            return Ok(request);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto request)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = request };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto request)
        {
            var command = new UpdateLeaveAllocationCommand { updateLeaveAllocationDto = request };
           await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
