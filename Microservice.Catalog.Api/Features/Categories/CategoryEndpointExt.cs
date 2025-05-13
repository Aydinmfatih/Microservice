using Asp.Versioning.Builder;
using Microservice.Catalog.Api.Features.Categories.Create;
using Microservice.Catalog.Api.Features.Categories.GetAll;
using Microservice.Catalog.Api.Features.Categories.GetById;

namespace Microservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEnpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/categories")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint();


        }
    }
}
