using System;

namespace Presentation.DTOs.SQL;

public class SQLTemplateDeleteOutputDTO
{

    public Guid Id { get; set; }

    public string Description { get; set; }

    public int Value {get; set;}
}
