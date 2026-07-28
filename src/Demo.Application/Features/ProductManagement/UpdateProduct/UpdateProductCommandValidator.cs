using Demo.Domain.Repositories;
using FluentValidation;

namespace Demo.Application.Features.ProductManagement.UpdateProduct;

public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty");
    }
}