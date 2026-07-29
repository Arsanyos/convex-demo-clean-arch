using Demo.Application.Common;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Demo.Domain.Repositories;
using MediatR;

namespace Demo.Application.Features.ProductManagement.DeleteProduct;

public sealed class DeleteProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<DeleteProductCommand, bool>, IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var toBeDeletedProductPublicId = command.PublicId;

        var deleted = await productRepository.DeleteAsync(toBeDeletedProductPublicId, cancellationToken);
        if (deleted is null)
        {
            return false;
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}