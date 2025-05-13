namespace Microservice.Catalog.Api.Features.Categories.GetById
{


    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async
                (IMediator mediator, Guid id) => (await mediator.Send(new GetCategoryByIdQuery(id)))
                .ToGenericResult())
                .WithName("GetByIdCategory");



            return group;
        }
    }


}
