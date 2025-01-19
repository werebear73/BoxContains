using BoxContains.Category.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BoxContains.Category.Persistence.Repositories;

/// <summary>
/// Repository for Categores
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly BoxContainsCategoryDbContext _dbcontext;

    /// <summary>
    /// Create the Repository for Categories
    /// </summary>
    /// <param name="dbContext"></param>
    public CategoryRepository(BoxContainsCategoryDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    /// <summary>
    /// Delete the Category
    /// </summary>
    /// <param name="id">Unique Identifier of the Category</param>
    public async Task DeleteCategoryAsync(int id)
    {
        var categoryToDelete = await _dbcontext.Categories.FindAsync(id);
        if (categoryToDelete != null)
        {
            _dbcontext.Categories.Remove(categoryToDelete);
            await _dbcontext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Get a list of all the categories
    /// </summary>
    /// <returns>list of all the categories</returns>
    public async Task<List<Domain.Category>> GetAllCategories()
    {
        return await _dbcontext.Categories.ToListAsync();
    }

    /// <summary>
    /// Get a Category by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Unique Identifier of the Category</returns>
    public async Task<Domain.Category?> GetByIdAsync(int id)
    {
        return await _dbcontext.Categories.FindAsync(id);
    }

    /// <summary>
    /// Update the details of the Category
    /// </summary>
    /// <param name="category">Category Instance</param>
    /// <returns>Category</returns>
    public async Task<Domain.Category> UpdateCategoryAsync(Domain.Category category)
    {
        _dbcontext.Entry(category).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
        return category;
    }

    /// <summary>
    /// Create a new Category
    /// </summary>
    /// <param name="category">Category Instance</param>
    /// <returns>Category</returns>
    public async Task<Domain.Category> AddCategoryAsync(Domain.Category category)
    {
        _dbcontext.Attach(category).State = EntityState.Added;        
        await _dbcontext.SaveChangesAsync();
        return category;
    }
}
