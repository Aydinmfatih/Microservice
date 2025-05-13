using Microservice.Catalog.Api.Features.Categories.Dtos;
using Microservice.Catalog.Api.Repositroies;
using System.Net;

namespace Microservice.Catalog.Api.Features.Categories.GetById
{
    public class GetCategoryByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (hasCategory is null)
            {
                return ServiceResult<CategoryDto>.Error("Category not found", $"Category with Id {request.Id} was not found", HttpStatusCode.NotFound);

            }
            var categoryDto = mapper.Map<CategoryDto>(hasCategory);
            return ServiceResult<CategoryDto>.SuccessAsOkey(categoryDto);
        }
    }


}
