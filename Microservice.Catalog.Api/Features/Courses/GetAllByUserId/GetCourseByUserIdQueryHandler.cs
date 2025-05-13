using Microservice.Catalog.Api.Features.Courses.Dtos;
using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public class GetCourseByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
        {
            public async Task<ServiceResult<List<CourseDto>>> Handle(GetCourseByUserIdQuery request, CancellationToken cancellationToken)
            {
                var courses = await context.Courses.Where(x=>x.UserId == request.UserId).ToListAsync(cancellationToken);

                var categories = await context.Categories.ToListAsync(cancellationToken);
                foreach (var course in courses)
                {
                    course.Category = categories.First(x => x.Id == course.CategoryId);
                }
                var courseDtos = mapper.Map<List<CourseDto>>(courses);
                return ServiceResult<List<CourseDto>>.SuccessAsOkey(courseDtos);
            }
        }
    
}
