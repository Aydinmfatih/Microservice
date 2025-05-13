using Microservice.Catalog.Api.Features.Courses.Dtos;
using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Courses.GetAll
{
    public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
{
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
         var courses = await context.Courses.ToListAsync(cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken);
            foreach (var course in courses)
            {
                course.Category = categories.First(x=>x.Id == course.CategoryId);
            }
            var courseDtos = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.SuccessAsOkey(courseDtos);


        }
    }
}
