namespace BoxContains.Category.Application.Exceptions;
/// <summary>
/// Application Exception for when the request is not proper
/// </summary>
public class BadRequestException : ApplicationException
{
    /// <summary>
    /// Create a Bad Request Exception
    /// </summary>
    /// <param name="message">Message to return for the Bad Request</param>
    public BadRequestException(string message) : base(message)
    {

    }
}