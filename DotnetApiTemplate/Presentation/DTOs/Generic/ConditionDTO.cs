using System.Text.Json;

namespace Presentation.DTOs.Generic;

public class ConditionDTO
{
    public string Key { get; set; }

    public JsonElement Value { get; set; }

    public string Operator { get; set; } = "==";
}
