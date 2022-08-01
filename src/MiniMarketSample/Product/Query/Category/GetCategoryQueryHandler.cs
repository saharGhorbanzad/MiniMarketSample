using Infrastructure.Interface;
using MediatR;
using Sheard.Query.Category;

namespace ProductApplication.Query
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryNameQuery, string>
    {
        IUnitOfWork unitOfWork;

        public GetCategoryQueryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<string> Handle(GetCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var existCategoryId = await unitOfWork.CategoryRepository.AnyCategoryIdAsync(request.CategoryId);
            if (existCategoryId)
            {
                var categoryName = await unitOfWork.CategoryRepository.GetCategoryNameAsync(request.CategoryId);
                return categoryName;
            }
            throw new NullReferenceException("not found");
        }
    }
}
