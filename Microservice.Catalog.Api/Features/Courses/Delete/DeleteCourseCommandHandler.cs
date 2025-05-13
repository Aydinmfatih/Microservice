using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Courses.Delete
{
    public class DeleteCourseCommandHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (hasCourse is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.Courses.Remove(hasCourse);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
