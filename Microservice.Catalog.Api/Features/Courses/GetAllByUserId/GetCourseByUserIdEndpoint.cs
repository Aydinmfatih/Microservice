namespace Microservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public static class GetCourseByIdEndpoint
        {
            public static RouteGroupBuilder GetByUserIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
            {
                group.MapGet("/user/{userId:guid}", async
                    (Guid userId, IMediator mediator) => (await mediator.Send(new GetCourseByUserIdQuery(userId))).ToGenericResult())
                    .WithName("GetCourseByUserId");


                return group;
            }
        }
    
}
