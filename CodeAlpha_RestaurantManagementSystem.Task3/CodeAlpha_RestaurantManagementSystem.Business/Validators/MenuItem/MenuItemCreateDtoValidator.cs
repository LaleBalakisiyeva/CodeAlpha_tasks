using CodeAlpha_RestaurantManagementSystem.Business.DTOs.MenuItemDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.MenuItem
{
    public class MenuItemCreateDtoValidator : AbstractValidator<MenuItemCreateDto>
    {
        public MenuItemCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Menu item name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");
        }
