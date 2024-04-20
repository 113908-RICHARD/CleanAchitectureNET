using Application.DTOs.LeaveType;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveTypes.Requests
{
    public class CreateLeaveTypeRequest : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto leaveType { get; set; }

    }
}
