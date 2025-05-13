using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Courses;
using Microservice.Catalog.Api.Repositroies;
using MongoDB.Driver;

namespace Microservice.Catalog.Api.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExt(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
             
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
               
                dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
                if (!dbContext.Categories.Any()) {

                    var categories = new List<Category>
                    {
                        new() {Id = NewId.NextSequentialGuid() , Name = "Category 1" },
                        new() {Id = NewId.NextSequentialGuid() , Name = "Category 2" },
                        new() {Id = NewId.NextSequentialGuid() , Name = "Category 3" },
                        new() {Id = NewId.NextSequentialGuid() , Name = "Category 3" }
                    };
                    await dbContext.Categories.AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.Courses.Any()) {

                    var category = await dbContext.Categories.FirstAsync();
                    
                    var courses = new List<Course>
                    {
                        new() {Id = NewId.NextSequentialGuid() , Name = "Course 1" , Description = "Description 1" , Price = 100 , ImageUrl = "https://example.com/image1.jpg" , CategoryId = category.Id,CreatedDate = DateTime.UtcNow  , UserId = NewId.NextSequentialGuid()},
                        new() {Id = NewId.NextSequentialGuid() , Name = "Course 2" , Description = "Description 2" , Price = 200 , ImageUrl = "https://example.com/image2.jpg" , CategoryId = category.Id ,CreatedDate = DateTime.UtcNow , UserId = NewId.NextSequentialGuid()},
                        new() {Id = NewId.NextSequentialGuid() , Name = "Course 3" , Description = "Description 3" , Price = 300 , ImageUrl = "https://example.com/image3.jpg" , CategoryId = category.Id ,CreatedDate = DateTime.UtcNow , UserId = NewId.NextSequentialGuid()},
                        new() {Id = NewId.NextSequentialGuid() , Name = "Course 4" , Description = "Description 4" , Price = 400 , ImageUrl = "https://example.com/image4.jpg" , CategoryId = category.Id ,CreatedDate = DateTime.UtcNow , UserId = NewId.NextSequentialGuid()}
                    };
                    await dbContext.Courses.AddRangeAsync(courses);
                    await dbContext.SaveChangesAsync();
                }

            }
        }
    }

}
