using BoxContains.Category.Application.Responses;

namespace BoxContains.Category.Application.Features.Queries.GetCategoryById;

public class GetCategoryByIdResponse : BaseResponse
{
    public GetCategoryByIdResponse() : base() { }
    public GetCategoryByIdDto? Category { get; set; }
}
