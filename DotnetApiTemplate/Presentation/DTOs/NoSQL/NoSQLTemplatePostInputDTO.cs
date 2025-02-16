using System;

namespace Presentation.DTOs.NoSQL;

public class NoSQLTemplatePostInputDTO
{
    public Guid Id {get; set;}
    public string Description {get; set;}

    public int Value { get; set; }
}
