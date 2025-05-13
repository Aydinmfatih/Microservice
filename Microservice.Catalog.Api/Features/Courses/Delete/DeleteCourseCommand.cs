namespace Microservice.Catalog.Api.Features.Courses.Delete
{
    public record class DeleteCourseCommand(Guid Id):IRequestByServiceResult;
}
