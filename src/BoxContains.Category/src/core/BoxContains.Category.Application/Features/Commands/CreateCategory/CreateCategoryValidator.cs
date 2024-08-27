using FluentValidation;

namespace BoxContains.Category.Application.Features.Commands.CreateCategory;

/// <summary>
/// Validator for the Create Category command to insure that proporties meet requirements.
/// </summary>
public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    /// <summary>
    /// Validator for the Create Category command to insure that proporties meet requirements.
    /// </summary>
    public CreateCategoryValidator() 
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty.");
        RuleFor(p => p.Name)
            .Length(1,255)
            .WithMessage("{PropertyName} can not be more than 255 characters.");
    }
}
