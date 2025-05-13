using Microservice.Catalog.Api.Features.Categories.Dtos;

namespace Microservice.Catalog.Api.Features.Categories.GetById
{
    public record class GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;


}
