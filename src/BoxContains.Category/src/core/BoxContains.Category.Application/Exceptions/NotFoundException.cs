namespace BoxContains.Category.Application.Exceptions;
/// <summary>
/// Application Exception for when the requested Category is not found
/// </summary>
public class NotFoundException : ApplicationException
{
    /// <summary>
    /// Create a Not Found Exception
    /// </summary>
    /// <param name="name">Name of Field searched in the Category</param>
    /// <param name="key">Value of Field searched in the Category</param>
    public NotFoundException(string name, object key)
        : base($"{name} ({key}) is not found")
    {
    }
}
