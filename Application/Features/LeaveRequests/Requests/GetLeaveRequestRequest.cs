using Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Requests
{
    public class GetLeaveRequestRequest : IRequest<LeaveRequestDto>
    {
        public int _Id { get; set; }
        public GetLeaveRequestRequest(int id)
        {
            _Id = id;
        }
    }
}
