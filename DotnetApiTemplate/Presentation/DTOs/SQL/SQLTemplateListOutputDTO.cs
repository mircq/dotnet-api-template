using System;

namespace Presentation.DTOs.SQL;

public class SQLTemplateListOutputDTO
{
    /// <summary>
    /// Template id
    /// </summary>
    /// <example>37b8b640-82af-452f-be77-dd3f9eaf53fc</example>
    public Guid Id { get; set; }

    /// <summary>
    /// Template description
    /// </summary>
    /// <example>This is a sample description</example>
    public string Description { get; set; }

    public int Value {get; set;}
}
