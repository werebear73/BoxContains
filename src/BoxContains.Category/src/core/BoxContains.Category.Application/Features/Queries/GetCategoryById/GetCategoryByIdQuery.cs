using MediatR;

namespace BoxContains.Category.Application.Features.Queries.GetCategoryById;
/// <summary>
/// Get Category by Id query class
/// </summary>
public class GetCategoryByIdQuery : IRequest<GetCategoryByIdResponse>
{
    /// <summary>
    /// Unique Identifier of the Category
    /// </summary>
    public int CategoryID { get; set; }
}
