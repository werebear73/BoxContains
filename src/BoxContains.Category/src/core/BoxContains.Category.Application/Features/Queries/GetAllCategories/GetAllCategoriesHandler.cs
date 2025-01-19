using AutoMapper;
using BoxContains.Category.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BoxContains.Category.Application.Features.Queries.GetAllCategories;

/// <summary>
/// Class for the Get All Categories query handler
/// </summary>
public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllCategoriesHandler> _logger;

    /// <summary>
    /// Construster for the Get All Categories handler
    /// </summary>
    /// <param name="categoryRepository"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetAllCategoriesHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handle the Get All Categories query
    /// </summary>
    /// <param name="query">Request query</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>

    public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _categoryRepository.GetAllCategories();
            var mappedCategories = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            var response = new GetAllCategoriesResponse()
            {
                Categories = mappedCategories
            };
            return response;
        }
        catch (Exception ex)
        {
            var response = new GetAllCategoriesResponse()
            {
                Success = false,
                Message = $"Handler Error: {ex.Message}\nStack Trace: {ex.StackTrace}",
                Categories = new List<GetAllCategoriesDto>()
            };
            return response;
        }
    }
}
