using AutoMapper;
using BoxContains.Category.Application.Contracts;
using BoxContains.Category.Application.Features.Queries.GetAllCategories;
using BoxContains.Category.Application.Profiles;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoxContains.Category.UnitTests;

public class GetAllCategoriesUnitTests
{
    private readonly Mapper _mapper;
    private readonly Mock<ICategoryRepository> _categoryRepository;

    public GetAllCategoriesUnitTests()
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
        int categoryId2 = (int)random.Next(1, int.MaxValue);
        _categoryRepository.Setup(x => x.GetAllCategories())
            .ReturnsAsync(new List<Domain.Category>()
            {
                new Domain.Category() {
                    CategoryID = categoryId1,
                    Name = "Test 1"
                },
                new Domain.Category() {
                    CategoryID = categoryId2,
                    Name = "Test 2"
                }
            });


        // Act
        var mockILogger = new Mock<ILogger<GetAllCategoriesHandler>>();
        ILogger<GetAllCategoriesHandler> _logger = mockILogger.Object;
        var handler = new GetAllCategoriesHandler(_categoryRepository.Object, _mapper, _logger );

        var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

        // Asset
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(2, (result.Categories ?? new List<GetAllCategoriesDto>()).Count() );
        
    }

    [Fact]
    public async Task GetAllCategories_ShouldReturnEmptyList_WhenQueryFails()
    {
        // Arrange
        _categoryRepository.Setup(repo => repo.GetAllCategories())
                       .ThrowsAsync(new Exception("Database error"));

        // Act
        var mockILogger = new Mock<ILogger<GetAllCategoriesHandler>>();
        ILogger<GetAllCategoriesHandler> _logger = mockILogger.Object;
        var handler = new GetAllCategoriesHandler(_categoryRepository.Object, _mapper, _logger);

        var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Handler Error",result.Message);
        if (result.Categories != null)
            Assert.Empty(result.Categories ?? new List<GetAllCategoriesDto>());

    }
}
