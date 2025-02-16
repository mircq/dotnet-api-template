using System;

namespace Presentation.DTOs.NoSQL;

public class NoSQLTemplatePutOutputDTO
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }

    public int Value { get; set; }
}
