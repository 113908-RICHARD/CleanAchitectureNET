﻿using Application.DTOs.Common;
using Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto: ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
       
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
