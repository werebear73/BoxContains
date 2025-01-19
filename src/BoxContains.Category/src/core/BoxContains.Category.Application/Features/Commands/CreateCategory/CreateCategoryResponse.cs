using BoxContains.Category.Application.Responses;

namespace BoxContains.Category.Application.Features.Commands.CreateCategory;

/// <summary>
/// The response to a create Category request
/// </summary>
public class CreateCategoryResponse : BaseResponse
{
    /// <summary>
    /// The response to a create Category request
    /// </summary>
    public CreateCategoryResponse() : base() { }

    public CreateCategoryDto? Category { get; set; }
}
