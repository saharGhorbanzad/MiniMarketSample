using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Product;
using Sheard.Dto.Product;

namespace ProductApplication.Command
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, InsertProductDto>
    {
        IUnitOfWork unitOfWork;
        public InsertProductCommandHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<InsertProductDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var existCategoryId = await unitOfWork.CategoryRepository.AnyCategoryIdAsync(request.CategoryId);
            if (existCategoryId)
            {
                unitOfWork.ProductRepository.AddEntity(new Entities.Model.Product
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = request.ProductName,
                    CategoryID = request.CategoryId,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitPrice = request.UnitPrice,
                    UnitsInStock = request.UnitsInStock
                });

                await unitOfWork.SaveChangesAsync(cancellationToken);

                var productDto = new InsertProductDto
                {
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitsInStock = request.UnitsInStock
                };

                return productDto;
            }
            else
            {
                throw new NullReferenceException("category not found");
            }
        }
    }
}
