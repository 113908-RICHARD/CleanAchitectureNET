using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LeaveType.Validators
{
    public class IleaveTypeDtoValidator: AbstractValidator<ILeaveTypeDto>
    {
        public IleaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters. ");

            RuleFor(p => p.DefaultDays)
              .NotEmpty().WithMessage("{PropertyName} is required")
          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
          .LessThan(100).WithMessage("{PropertyName} must be lower than 100"); 
        }
    }
}
