using Domain.Entities;

namespace Presentation.Mappers.Generic;

public static class OperatorMapper
{
    public static OperatorEntity ToEntity(string stringOperator)
    {
        switch(stringOperator)
        {
            case var op when op == "==":
                return OperatorEntity.Equal;
            case var op when op == "!=":
                return OperatorEntity.NotEqual;
            case var op when op == "<":
                return OperatorEntity.Lower;
            case var op when op == "<=":
                return OperatorEntity.LowerOrEqual;
            case var op when op == ">":
                return OperatorEntity.Greater;
            case var op when op == ">=":
                return OperatorEntity.GreaterOrEqual;
            default:
                throw new Exception($"Operator {stringOperator} not supported.");
        }
    }

    public static OperatorDTO ToDTO(OperatorEntity entity)
    {
        switch(entity)
        {
            case var op when op == OperatorEntity.Equal:
                return OperatorDTO.Equal;
            case var op when op == OperatorEntity.NotEqual:
                return OperatorDTO.NotEqual;
            case var op when op == OperatorEntity.Lower:
                return OperatorDTO.Lower;
            case var op when op == OperatorEntity.LowerOrEqual:
                return OperatorDTO.LowerOrEqual;
            case var op when op == OperatorEntity.Greater:
                return OperatorDTO.Greater;
            case var op when op == OperatorEntity.GreaterOrEqual:
                return OperatorDTO.GreaterOrEqual;
            default:
                throw new Exception($"Operator {entity} not supported.");
        }
    }
}
