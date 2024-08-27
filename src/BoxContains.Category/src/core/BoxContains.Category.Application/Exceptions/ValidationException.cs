using FluentValidation.Results;

namespace BoxContains.Category.Application.Exceptions;
/// <summary>
/// Application Exception for when the Validation of the Category fails.
/// </summary>
public class ValidationException : ApplicationException
{
    /// <summary>
    /// List of the Validation Errors
    /// </summary>
    public List<string> ValdationErrors { get; set; }

    /// <summary>
    /// Create a Validation Exception
    /// </summary>
    /// <param name="validationResult">Result from Fluent Validation</param>
    public ValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}