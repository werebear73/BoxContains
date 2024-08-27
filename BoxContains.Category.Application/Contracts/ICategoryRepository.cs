using BoxContains.Category.Domain;

namespace BoxContains.Category.Application.Contracts;

public interface ICategoryRepository
{
    /// <summary>
    /// Get the Category by ID
    /// </summary>
    /// <param name="id">Unique Identifier of the Category</param>
    /// <returns>Category</returns>
    Task<Domain.Category> GetByIdAsync(int id);
    /// <summary>
    /// Get All the Categories
    /// </summary>
    /// <returns>List of Categories</returns>
    Task<List<Domain.Category>> GetAllCategories();
    /// <summary>
    /// Add a Category
    /// </summary>
    /// <param name="category">Category</param>
    /// <returns>Category</returns>
    Task<Domain.Category> AddCategoryAsync(Domain.Category category);
    /// <summary>
    /// Update the Category details
    /// </summary>
    /// <param name="category">Category</param>
    /// <returns>Category</returns>
    Task<Domain.Category> UpdateCategoryAsync(Domain.Category category);
    /// <summary>
    /// Deletes the Category
    /// </summary>
    /// <param name="id">Unique Identifier of the Category</param>
    Task DeleteCategoryAsync(int id);

}
