namespace Domain.Entities;

public class ConditionEntity
{
    public string Key { get; set; }

    public object Value { get; set; }

    public Operator Operator { get; set; } = Operator.Equal;
}
