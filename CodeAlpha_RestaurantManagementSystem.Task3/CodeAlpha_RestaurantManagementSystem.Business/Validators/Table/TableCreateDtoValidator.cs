using CodeAlpha_RestaurantManagementSystem.Business.DTOs.TableDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Validators.Table
{
    public class TableCreateDtoValidator : AbstractValidator<TableCreateDto>
    {
        public TableCreateDtoValidator()
        {
            RuleFor(x => x.TableNumber)
                .GreaterThan(0).WithMessage("Table number must be greater than 0.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Table capacity must be at least 1.");
        }
    }
}
