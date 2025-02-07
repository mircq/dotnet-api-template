namespace Presentation.DTOs.Generic;

public class ConditionDTO
{
    public string Key { get; set; }

    public object Value { get; set; }

    public string Operator { get; set; } = "==";
}
