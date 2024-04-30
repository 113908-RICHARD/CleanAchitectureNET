using Application.DTOs.LeaveRequest;
using Application.Features.LeaveRequests.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var response = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(response);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>>Get(int Id)
        {
            var response = await _mediator.Send(new GetLeaveRequestRequest(Id));
            return Ok(response);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto dto) 
        {
            var request = new CreateLeaveRequestCommand { CreateLeaveRequestDto = dto };
           var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]UpdateLeaveRequestDto dto)
        {
            var request = new UpdateLeaveRequestCommand { Id = id,leaveRequestDto = dto };
           await _mediator.Send(request);
            return NoContent();

        }

        [HttpPut("changeapproval")]
        public async Task<ActionResult> ChangeApproval(int id,[FromBody] ChangeLeaveRequestApprovalDto dto)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApproval = dto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
