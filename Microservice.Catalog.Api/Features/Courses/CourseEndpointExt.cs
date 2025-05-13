using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Catalog.Api.Features.Courses.GetAll;
using Microservice.Catalog.Api.Features.Courses.GetById;
using Microservice.Catalog.Api.Features.Courses.Update;
using Microservice.Catalog.Api.Features.Courses.Delete;
using Microservice.Catalog.Api.Features.Courses.GetAllByUserId;
using Asp.Versioning.Builder;


namespace Microservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCoursegroupEnpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/courses")
                .WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetByUserIdCourseGroupItemEndpoint();
        }
    }
}
