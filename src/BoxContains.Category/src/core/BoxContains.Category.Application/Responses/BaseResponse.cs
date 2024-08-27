namespace BoxContains.Category.Application.Responses;

/// <summary>
/// Base Response to Application Requests
/// </summary>
public class BaseResponse
{
    /// <summary>
    /// Constructor for the Base Response
    /// </summary>
    public BaseResponse()
    {
        Success = true;
    }
    /// <summary>
    /// Constructor for the Base Response
    /// </summary>
    /// <param name="message">Message in the Response</param>
    public BaseResponse(string? message = null)
    {
        Success = true;
        Message = message;
    }
    /// <summary>
    /// Constructor for the Base Response
    /// </summary>
    /// <param name="message">Message in the Response</param>
    /// <param name="success">Whether or not the Request was successful</param>
    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    /// <summary>
    /// Whether or not the Request was successful
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// Message in the Response
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// List of Validation Errors in the Request
    /// </summary>
    public List<string>? ValidationErrors { get; set; }
}
