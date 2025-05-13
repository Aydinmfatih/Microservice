using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCourseResponse>>
    {
        public async Task<ServiceResult<CreateCourseResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (existCategory)
            {
                return ServiceResult<CreateCourseResponse>.Error($"Category  name  already exists.", $"The category name '{request.Name}' already exist", HttpStatusCode.BadRequest);
            }
            var category = new Category
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid()
            };
            await context.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult<CreateCourseResponse>.SuccessAsCreated(new CreateCourseResponse(category.Id), $"Category '{category.Name}' created successfully.");
        }
    }
}
