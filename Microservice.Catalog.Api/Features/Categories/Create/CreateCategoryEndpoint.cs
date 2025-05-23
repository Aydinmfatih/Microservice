﻿using Microservice.Shared.Filters;

namespace Microservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async
                (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateCategory")
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();


            return group;
        }
    }
}
