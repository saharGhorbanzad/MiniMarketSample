using Entities.Model;
using Infrastructure.Interface;
using MediatR;
using Sheard.Command.Category;
using Sheard.Dto.Category;


namespace ProductApplication.Command
{
    public class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommand, InsertCategoryDto>
    {
        private IUnitOfWork UnitOfWork;

        public InsertCategoryCommandHandler(IUnitOfWork _unitOfWork)
        {
            UnitOfWork = _unitOfWork;
        }

        public async Task<InsertCategoryDto> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await UnitOfWork.CategoryRepository.AnyCategoryNameAsync(request.CategoryName);
            if (!existCategory)
            {
                UnitOfWork.CategoryRepository.AddEntity(new Category
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    Picture = request.Picture,
                });

                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var categoryDto = new InsertCategoryDto
                {
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    Picture = request.Picture
                };
                return categoryDto;
            }
            else
            {
                throw new NullReferenceException("category is exist");
            }
        }
    }
}
