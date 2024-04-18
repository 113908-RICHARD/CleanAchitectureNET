﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface  ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeavesRequestWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest,bool? status);
    }
}
