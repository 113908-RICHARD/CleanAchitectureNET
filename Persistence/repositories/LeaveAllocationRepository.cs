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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaveAllocationRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = _dbContext.LeaveAllocation
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = _dbContext.LeaveAllocation
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == Id);
            return leaveAllocation;
        }
    }
}
