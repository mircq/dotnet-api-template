namespace Domain.Entities;

public record Operator
{
    private Operator(string value) => Value = value;

    public string Value { get; }

    public static readonly Operator Equal = new(value: "==");
    public static readonly Operator Contains = new(value: "contains");
    public static readonly Operator Greater = new(value: ">");
    public static readonly Operator GreaterOrEqual = new(value: ">=");
    public static readonly Operator Lower = new(value: "<");
    public static readonly Operator LowerOrEqual = new(value: "<=");

    public static bool IsValid(string value) =>
        value == Equal.Value || 
        value == Contains.Value || 
        value == Greater.Value || 
        value == GreaterOrEqual.Value ||
        value == Lower.Value || 
        value == LowerOrEqual.Value;

    public override string ToString() => Value;
}
