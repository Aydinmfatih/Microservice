namespace Microservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandValidator:AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Name is required.")
                  .MaximumLength(100)
                  .WithMessage(" {PropertyName} Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(500)
                .WithMessage(" {PropertyName} Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} Price must be greater than 0.");


            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Category ID is required.");
        }
    }
}
