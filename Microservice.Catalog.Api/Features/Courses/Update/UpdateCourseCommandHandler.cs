
using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context , IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            if (hasCourse is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            hasCourse.Name = request.Name;
            hasCourse.Description = request.Description;
            hasCourse.Price = request.Price;
            hasCourse.ImageUrl = request.ImageUrl;
            hasCourse.CategoryId = request.CategoryId;

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }

}
