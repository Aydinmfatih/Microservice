﻿using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Repositroies;

namespace Microservice.Catalog.Api.Features.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public Feature? Feature { get; set; } = default!;

    }
}
