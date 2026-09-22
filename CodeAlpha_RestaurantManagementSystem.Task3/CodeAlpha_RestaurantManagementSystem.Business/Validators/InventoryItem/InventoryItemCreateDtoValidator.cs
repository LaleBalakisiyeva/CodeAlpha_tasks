using CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.InventoryItem
{
    public class InventoryItemCreateDtoValidator : AbstractValidator<InventoryItemCreateDto>
    {
        public InventoryItemCreateDtoValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("Inventory item name is required.")
                .MaximumLength(100).WithMessage("Item name cannot exceed 100 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit of measurement is required.");

            RuleFor(x => x.MinimumRequiredQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum required quantity cannot be negative.");
        }
    }
}
