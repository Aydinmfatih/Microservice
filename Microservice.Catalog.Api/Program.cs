using MediatR;
using Microservice.Catalog.Api;
using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Courses;
using Microservice.Catalog.Api.Options;
using Microservice.Catalog.Api.Repositories;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Dependency Injection Extensions ---
builder.Services.AddMongoOptionExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));




var app = builder.Build();

app.AddSeedDataExt().ContinueWith(x =>
{

    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data completed");

});
// --- Endpoint Route Mappings ---
app.AddCategoryGroupEnpointExt(app.AddVersionSetExt());
app.AddCoursegroupEnpointExt(app.AddVersionSetExt());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

