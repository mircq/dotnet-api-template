namespace Domain.Entities;

public class ConditionEntity
{
    public string Key { get; set; }

    public string Value { get; set; }

    public Operator Operator { get; set; } = Operator.Equal;
}
