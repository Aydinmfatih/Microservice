using Microservice.Catalog.Api.Features.Courses.GetAll;

namespace Microservice.Catalog.Api.Features.Courses.GetById
{

    public static class GetCourseByIdeEndpoint
    {
        public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async
                (Guid id,IMediator mediator) => (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult())
                .WithName("GetCourseById");


            return group;
        }
    }
}
