namespace Domain.Entities;

public record OperatorEntity
{
    private OperatorEntity(string value) => Value = value;

    public string Value { get; }

    public static readonly OperatorEntity Equal = new(value: "==");

    public static readonly OperatorEntity NotEqual = new(value: "!=");
    public static readonly OperatorEntity Contains = new(value: "contains");
    public static readonly OperatorEntity Greater = new(value: ">");
    public static readonly OperatorEntity GreaterOrEqual = new(value: ">=");
    public static readonly OperatorEntity Lower = new(value: "<");
    public static readonly OperatorEntity LowerOrEqual = new(value: "<=");

    public static bool IsValid(string value) =>
        value == Equal.Value || 
        value == NotEqual.Value ||
        value == Contains.Value || 
        value == Greater.Value || 
        value == GreaterOrEqual.Value ||
        value == Lower.Value || 
        value == LowerOrEqual.Value;

    public override string ToString() => Value;
}
