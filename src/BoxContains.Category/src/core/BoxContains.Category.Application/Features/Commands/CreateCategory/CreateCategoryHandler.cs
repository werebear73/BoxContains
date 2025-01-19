using AutoMapper;
using BoxContains.Category.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BoxContains.Category.Application.Features.Commands.CreateCategory;

/// <summary>
/// Handler Class for Create Category requests
/// </summary>
public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    // private variables
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initiate handler for Create Category requests
    /// </summary>
    public CreateCategoryHandler (IMapper mapper, ILogger<CreateCategoryHandler> logger, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Handle Create Category request
    /// </summary>
    /// <param name="command">The command for Create Category requests</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Instance of the Category requested</returns>
    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        // Prepare response
        var response = new CreateCategoryResponse();

        // Conduct validation
        var validator = new CreateCategoryValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        // Check for validation errors if present response with the details of the errors
        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        // If validation is successful, create Category
        if (response.Success)
        {
            var category = new Domain.Category()
            {
                Name = command.Name,
            };

            // Send the category to the repository for creation
            category = await _categoryRepository.AddCategoryAsync(category);

            // Map the Category to the DTO
            response.Category = _mapper.Map<CreateCategoryDto>(category);
        }
        
        // Return Response
        return response;
    }

}
