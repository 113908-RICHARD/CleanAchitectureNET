﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocations.Requests
{
    public class DeleteLeaveAllocationCommand:IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
