using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandValidator : AbstractValidator<CreateNewProductCommand>
    {
        public CreateNewProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} zorunlu.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} en fazla 200 karakter olmalı");
            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyName} en fazla 400 karakter olmalı");
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} zorunlu.")
                .GreaterThan(0);
            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0);
        }
    }
}
