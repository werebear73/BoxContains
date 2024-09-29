using AutoMapper;
using BoxContains.Category.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BoxContains.Category.Application.Features.Queries.GetCategoryById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCategoryByIdHandler> _logger;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryByIdHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new GetCategoryByIdResponse();

            var category = await _categoryRepository.GetByIdAsync(request.CategoryID);
            if (category == null)
            {
                _logger.LogInformation($"Catgory Not Found for ID: {request.CategoryID}");
                response.Success = false;
                response.Message = $"Category Not Found for ID: {request.CategoryID}";
                return response;
            }

            response.Success = true;
            response.Category = _mapper.Map<GetCategoryByIdDto>(category);
            return response;
        }
        catch (Exception ex)
        {
            var response = new GetCategoryByIdResponse()
            {
                Success = false,
                Message = $"Handler Error: {ex.Message}\nStack Trace: {ex.StackTrace}",
                Category = null
            };
            return response;
        }
    }
}
