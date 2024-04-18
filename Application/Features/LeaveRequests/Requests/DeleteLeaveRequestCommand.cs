using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Requests
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
