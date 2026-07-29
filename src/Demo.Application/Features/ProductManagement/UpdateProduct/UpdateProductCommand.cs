using Demo.Application.Common;
using Demo.Contracts.Enums;

namespace Demo.Application.Features.ProductManagement.UpdateProduct;

public record UpdateProductCommand : ICommand<UpdateProductDto>
{
    public required Guid PublicId { get; init; }
    public required string Name { get; init; }
    public decimal Price { get; init; }
    public string? Description { get; init; }
    public ProductStatus Status { get; init; }
}