using CodeAlpha_RestaurantManagementSystem.Business.DTOs.ReservationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.Reservation
{
    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.");

            RuleFor(x => x.CustomerPhone)
                .NotEmpty().WithMessage("Customer phone number is required.");

            RuleFor(x => x.ReservationTime)
                .GreaterThan(DateTime.Now).WithMessage("Reservation time cannot be in the past.");

            RuleFor(x => x.GuestCount)
                .GreaterThan(0).WithMessage("Guest count must be at least 1.");
        }
    }
}
