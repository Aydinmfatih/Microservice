using Microservice.Catalog.Api.Features.Courses.Update;
using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Courses.Delete
{
    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/{id:guid}", async
                (Guid id, IMediator mediator) => (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
                .WithName("DeleteCourse");
               


            return group;
        }
    }
}
