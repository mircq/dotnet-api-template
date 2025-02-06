using Domain.Entities;

namespace Presentation.Mappers.Generic;

public static class OperatorMapper
{
    public static Operator ToEntity(string stringOperator)
    {
        switch(stringOperator)
        {
            case var op when op == "==":
                return Operator.Equal;
            case var op when op == "<":
                return Operator.Lower;
            case var op when op == "<=":
                return Operator.LowerOrEqual;
            case var op when op == ">":
                return Operator.Greater;
            case var op when op == ">=":
                return Operator.GreaterOrEqual;
            default:
                throw new Exception($"Operator {stringOperator} not supported.");
        }
    }

    public static OperatorDTO ToDTO(Operator entity)
    {
        switch(entity)
        {
            case var op when op == Operator.Equal:
                return OperatorDTO.Equal;
            case var op when op == Operator.Lower:
                return OperatorDTO.Lower;
            case var op when op == Operator.LowerOrEqual:
                return OperatorDTO.LowerOrEqual;
            case var op when op == Operator.Greater:
                return OperatorDTO.Greater;
            case var op when op == Operator.GreaterOrEqual:
                return OperatorDTO.GreaterOrEqual;
            default:
                throw new Exception($"Operator {entity} not supported.");
        }
    }
}
