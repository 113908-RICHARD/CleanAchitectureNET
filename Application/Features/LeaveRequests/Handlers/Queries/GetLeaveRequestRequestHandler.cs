using Application.DTOs.LeaveRequest;
using Application.Features.LeaveRequests.Requests;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestRequestHandler : IRequestHandler<GetLeaveRequestRequest, LeaveRequestDto>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;

        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            var result = await _leaveRequestRepository.GetLeaveRequestWithDetails(request._Id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<LeaveRequestDto>(result);
        }
    }
}
