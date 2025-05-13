using Microservice.Catalog.Api.Features.Categories.Dtos;
using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryHandler(AppDbContext context,IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
      

        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken);
           var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
            return ServiceResult<List<CategoryDto>>.SuccessAsOkey(categoriesAsDto);
        }
    }
}
