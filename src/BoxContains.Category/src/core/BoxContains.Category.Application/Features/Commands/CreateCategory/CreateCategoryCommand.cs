using MediatR;

namespace BoxContains.Category.Application.Features.Commands.CreateCategory;

/// <summary>
/// The command class for creating a Category
/// </summary>
public class CreateCategoryCommand : IRequest<CreateCategoryResponse>
{
    /// <summary>
    /// Name of the Category
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
