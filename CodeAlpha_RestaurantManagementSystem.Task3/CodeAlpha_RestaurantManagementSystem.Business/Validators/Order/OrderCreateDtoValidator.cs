using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.Order
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.TableId)
                .GreaterThan(0).WithMessage("Table ID must be valid and greater than 0.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Order must contain at least one item.");
        }
    }
}
