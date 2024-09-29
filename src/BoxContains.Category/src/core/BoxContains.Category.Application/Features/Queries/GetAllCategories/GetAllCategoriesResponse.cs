using BoxContains.Category.Application.Responses;

namespace BoxContains.Category.Application.Features.Queries.GetAllCategories;

/// <summary>
/// Response to a Get All Categories query
/// </summary>
public class GetAllCategoriesResponse : BaseResponse
{
    /// <summary>
    /// Constructer for the Get All Categories query
    /// </summary>
    public GetAllCategoriesResponse() : base() { }

    /// <summary>
    /// List of the Data Transfer Objects for Categories
    /// </summary>
    public List<GetAllCategoriesDto>? Categories { get; set; }
}
