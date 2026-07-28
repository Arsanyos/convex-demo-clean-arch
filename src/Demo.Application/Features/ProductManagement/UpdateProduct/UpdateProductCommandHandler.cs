using Demo.Application.Common;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using Demo.Domain.Repositories;
using MediatR;

namespace Demo.Application.Features.ProductManagement.UpdateProduct;

public sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateProductCommand, UpdateProductDto>
{
    public async Task<UpdateProductDto> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            PublicId = command.PublicId,
            
        };
        var publicId = command.PublicId;
        
        var updated =  await productRepository.UpdateAsync(product,publicId,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateProductDto(
            updated.Id,
            updated.PublicId,
            updated.Name,
            updated.Description,
            updated.Price,
            updated.Status
        );
    }
}