using CodeAlpha_EventRegistrationSystem.Business.DTOs.Event;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Validators.Event
{
    public class EventCreateDtoValidator : AbstractValidator<EventCreateDto>
    {
        public EventCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.EventDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Event date must be in the future.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");
        }
    }
}
