using Demo.Application.Common;

namespace Demo.Application.Features.ProductManagement.DeleteProduct;

public sealed record DeleteProductCommand : ICommand<bool>
{
    public required Guid PublicId { get; init; }
}