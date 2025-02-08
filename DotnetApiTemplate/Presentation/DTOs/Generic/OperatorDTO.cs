public record OperatorDTO
{
    private OperatorDTO(string value) => Value = value;

    public string Value { get; }

    public static readonly OperatorDTO Equal = new(value: "==");

    public static readonly OperatorDTO NotEqual = new(value: "!=");
    public static readonly OperatorDTO Contains = new(value: "contains");
    public static readonly OperatorDTO Greater = new(value: ">");
    public static readonly OperatorDTO GreaterOrEqual = new(value: ">=");
    public static readonly OperatorDTO Lower = new(value: "<");
    public static readonly OperatorDTO LowerOrEqual = new(value: "<=");

    public static bool IsValid(string value) =>
        value == Equal.Value || 
        value == Contains.Value || 
        value == Greater.Value || 
        value == GreaterOrEqual.Value ||
        value == Lower.Value || 
        value == LowerOrEqual.Value;

    public override string ToString() => Value;
}