using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaveRequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? status)
        {
            leaveRequest.Approved = status;
            _dbContext.Entry(leaveRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequests = await _dbContext.LeaveRequest
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);        
                 
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeavesRequestWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequest
              .Include(q => q.LeaveType)
              .ToListAsync();
            return leaveRequests;
        }
    }
}
