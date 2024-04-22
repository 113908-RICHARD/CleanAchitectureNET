using Application.DTOs.LeaveType.Validators;
using Application.Exceptions;
using Application.Features.LeaveTypes.Requests;
using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeRequestHandler : IRequestHandler<CreateLeaveTypeRequest, BaseCommandResponse>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveType, cancellationToken);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.Message = "Creation Failed";
                result.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var leaveType = _mapper.Map<LeaveType>(request.leaveType);
            leaveType = await _leaveTypeRepository.Add(leaveType);
            result.Success = true;
            result.Message = "Creation succesful";
            result.Id = leaveType.Id;
            return result;
        }
    }
}
