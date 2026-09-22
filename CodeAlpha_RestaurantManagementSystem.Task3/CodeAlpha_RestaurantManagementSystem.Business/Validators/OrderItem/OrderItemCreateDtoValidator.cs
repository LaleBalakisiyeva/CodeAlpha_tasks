using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderItemDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.OrderItem
{
    public class OrderItemCreateDtoValidator : AbstractValidator<OrderItemCreateDto>
    {
        public OrderItemCreateDtoValidator()
        {
            RuleFor(x => x.MenuItemId)
                .GreaterThan(0).WithMessage("Menu item ID must be valid.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
