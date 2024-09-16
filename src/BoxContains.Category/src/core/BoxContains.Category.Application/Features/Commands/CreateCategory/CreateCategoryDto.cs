﻿namespace BoxContains.Category.Application.Features.Commands.CreateCategory;

/// <summary>
/// Date Transfer Object for a Category that is created
/// </summary>
public class CreateCategoryDto
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