using Microservice.Catalog.Api.Features.Courses.Dtos;

namespace Microservice.Catalog.Api.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
}
