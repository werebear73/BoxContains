using AutoMapper;
using BoxContains.Category.Application.Contracts;
using BoxContains.Category.Application.Features.Commands.CreateCategory;
using BoxContains.Category.Application.Profiles;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoxContains.Category.UnitTests
{
    public class CreateCategoryUnitTests
    {
        private readonly Mapper _mapper;
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly IValidator<CreateCategoryCommand> _validator;

        public CreateCategoryUnitTests() 
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            _mapper = new Mapper(configuration);
            _categoryRepository = new Mock<ICategoryRepository>();
            _validator = new CreateCategoryValidator();
        }

        [Fact]
        public async void Successful()
        {
            // Arrange
            Random random = new Random();
            int categoryId = (int)random.Next(1, int.MaxValue);
            _categoryRepository.Setup(x => x.AddCategoryAsync(It.IsAny<Domain.Category>()))
                .ReturnsAsync(new Domain.Category()
                {
                    CategoryID = categoryId,
                    Name = "Test"
                });

            // Act
            var mockILogger = new Mock<ILogger<CreateCategoryHandler>>();
            ILogger<CreateCategoryHandler> _logger = mockILogger.Object;
            var handler = new CreateCategoryHandler(_mapper, _logger, _categoryRepository.Object);

            var result = await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            if (result.Category != null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Assert.Equal(categoryId, result.Category.CategoryID);
                Assert.Equal("Test", result.Category.Name);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            Assert.True(result.Success);
        }

        [Fact]
        public void ShouldFailWhenNameIsEmpty()
        {
            // Arrange
            var testCategory = new CreateCategoryCommand() { Name = "" };

            // Act
            FluentValidation.Results.ValidationResult result = _validator.Validate(testCategory);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name can not be less than 1 character or more than 255 characters.");
        }

    }
}