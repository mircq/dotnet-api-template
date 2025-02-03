namespace Presentation.DTOs.Generic;

public class ConditionDTO
{
    public string Key { get; set; }

    public string Value { get; set; }

    public OperatorDTO Operator { get; set; } = OperatorDTO.Equal;
}
