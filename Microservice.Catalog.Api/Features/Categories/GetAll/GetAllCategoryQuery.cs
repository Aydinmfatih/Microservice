using Microservice.Catalog.Api.Features.Categories.Dtos;

namespace Microservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery : IRequestByServiceResult<List<CategoryDto>>;
}