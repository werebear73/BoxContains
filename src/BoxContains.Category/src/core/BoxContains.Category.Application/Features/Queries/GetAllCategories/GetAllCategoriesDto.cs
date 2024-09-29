namespace BoxContains.Category.Application.Features.Queries.GetAllCategories;
/// <summary>
/// Class for the Category of Items Data Transfer Object
/// </summary>
/// <remarks>
/// These are the type or classification grouping for items such as kitchware, hobby materials, seasonal decor, etc
/// </remarks>
public class GetAllCategoriesDto
{
    /// <summary>
    /// Unique Identifier of the Category
    /// </summary>
    public int CategoryID { get; set; }
    /// <summary>
    /// Name of the Category
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

}
