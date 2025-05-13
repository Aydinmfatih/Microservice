using Microservice.Catalog.Api.Features.Courses.Dtos;

namespace Microservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public record GetCourseByUserIdQuery(Guid UserId) : IRequestByServiceResult<List<CourseDto>>;
    
}
