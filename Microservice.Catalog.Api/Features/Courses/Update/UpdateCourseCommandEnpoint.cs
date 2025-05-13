using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Courses.Update
{
    public static class UpdateCourseCommandEnpoint
    {
       
            public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
            {
                group.MapPut("/", async
                    (UpdateCourseCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
                    .WithName("UpdateCourse")
                    .AddEndpointFilter<ValidationFilter<UpdateCourseCommandValidator>>();


                return group;
            }
        
    }
}
