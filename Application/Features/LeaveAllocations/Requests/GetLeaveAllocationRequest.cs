﻿using Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Requests
{
    public class GetLeaveAllocationRequest:IRequest<LeaveAllocationDto>

    {
        public int _Id { get; set; }

        public GetLeaveAllocationRequest(int Id)
        {
            _Id = Id;
        }
    }
}
