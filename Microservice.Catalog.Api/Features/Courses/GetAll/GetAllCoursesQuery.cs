using Microservice.Catalog.Api.Features.Courses.Dtos;

namespace Microservice.Catalog.Api.Features.Courses.GetAll
{
    public record GetAllCoursesQuery():IRequestByServiceResult<List<CourseDto>>;
}
