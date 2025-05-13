using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Courses.GetAll
{

    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async
                (IMediator mediator) => (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                .WithName("GetAllCourses");


            return group;
        }
    }
}
