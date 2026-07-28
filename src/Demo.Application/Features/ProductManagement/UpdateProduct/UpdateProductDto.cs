using Demo.Contracts.Enums;

namespace Demo.Application.Features.ProductManagement.UpdateProduct;

public sealed record UpdateProductDto(
    long Id,
    Guid PublicId,
    string Name,
    string? Description,
    decimal? Price,
    ProductStatus? Status
    );