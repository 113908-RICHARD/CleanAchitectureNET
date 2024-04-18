using Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Requests
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>

    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto leaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApproval { get; set; }
    }
}
