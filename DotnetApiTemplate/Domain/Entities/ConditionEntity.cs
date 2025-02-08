using System.Text.Json;

namespace Domain.Entities;

public class ConditionEntity
{
    public string Key { get; set; }

    public JsonElement Value { get; set; }

    public OperatorEntity Operator { get; set; } = OperatorEntity.Equal;
}
