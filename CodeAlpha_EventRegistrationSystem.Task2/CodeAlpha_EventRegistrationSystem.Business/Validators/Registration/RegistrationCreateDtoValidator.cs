using CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Validators.Registration
{
    public class RegistrationCreateDtoValidator : AbstractValidator<RegistrationCreateDto>
    {
        public RegistrationCreateDtoValidator()
        {
            RuleFor(x => x.EventId)
                .GreaterThan(0).WithMessage("A valid Event ID is required.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("A valid User ID is required.");
        }
    }
}
