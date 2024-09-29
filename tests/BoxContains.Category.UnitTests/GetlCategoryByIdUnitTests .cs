using AutoMapper;
using BoxContains.Category.Application.Contracts;
using BoxContains.Category.Application.Features.Queries.GetCategoryById;
using BoxContains.Category.Application.Profiles;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoxContains.Category.UnitTests;

public class GetlCategoryByIdUnitTests
{
    private readonly Mapper _mapper;
    private readonly Mock<ICategoryRepository> _categoryRepository;

    public GetlCategoryByIdUnitTests()
    {
        var mappingProfile = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
        _mapper = new Mapper(configuration);
        _categoryRepository = new Mock<ICategoryRepository>();
    }

    [Fact]
    public async void Successful()
    {
        // Arrange
        Random random = new Random();
        int categoryId1 = (int)random.Next(1, int.MaxValue);
        string categoryName = "Test 1";
        _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(
                new Domain.Category() {
                    CategoryID = categoryId1,
                    Name = categoryName
                });


        // Act
        var mockILogger = new Mock<ILogger<GetCategoryByIdHandler>>();
        ILogger<GetCategoryByIdHandler> _logger = mockILogger.Object;
        var handler = new GetCategoryByIdHandler(_categoryRepository.Object, _mapper, _logger );

        var request = new GetCategoryByIdQuery() { CategoryID = 1 };
        var result = await handler.Handle(request, CancellationToken.None);

        // Asset
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(categoryName, (result.Category ?? new GetCategoryByIdDto() { CategoryID = 0, Name = "Bad"}).Name );
        
    }

    [Fact]
    public async Task GetAllCategories_ShouldReturnNull_WhenIdNotFound()
    {
        // Arrange
        var nullValue = (Domain.Category?) null ;
        _categoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                       .ReturnsAsync(nullValue);

        // Act
        var mockILogger = new Mock<ILogger<GetCategoryByIdHandler>>();
        ILogger<GetCategoryByIdHandler> _logger = mockILogger.Object;
        var handler = new GetCategoryByIdHandler(_categoryRepository.Object, _mapper, _logger);

        var result = await handler.Handle(new GetCategoryByIdQuery() { CategoryID = 1 }, CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Category Not Found for ID:", result.Message);
        Assert.Null(result.Category);

    }

    [Fact]
    public async Task GetAllCategories_ShouldReturnNull_WhenQueryFails()
    {
        // Arrange
        _categoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var mockILogger = new Mock<ILogger<GetCategoryByIdHandler>>();
        ILogger<GetCategoryByIdHandler> _logger = mockILogger.Object;
        var handler = new GetCategoryByIdHandler(_categoryRepository.Object, _mapper, _logger);

        var result = await handler.Handle(new GetCategoryByIdQuery() { CategoryID = 1}, CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Handler Error",result.Message);
        Assert.Null(result.Category);

    }
}
