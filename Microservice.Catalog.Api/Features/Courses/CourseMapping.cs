using Microservice.Catalog.Api.Features.Courses.Create;
using Microservice.Catalog.Api.Features.Courses.Dtos;

namespace Microservice.Catalog.Api.Features.Courses
{
    public class CourseMapping:Profile
        {
        public CourseMapping()
        {
            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
    }
