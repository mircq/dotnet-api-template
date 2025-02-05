using Domain.Entities;

namespace Presentation.Mappers.Generic;

public class OperatorMapper
{
    public Operator ToEntity(OperatorDTO dto)
    {
        switch(dto)
        {
            case var op when op == OperatorDTO.Equal:
                return Operator.Equal;
            case var op when op == OperatorDTO.Lower:
                return Operator.Lower;
            case var op when op == OperatorDTO.LowerOrEqual:
                return Operator.LowerOrEqual;
            case var op when op == OperatorDTO.Greater:
                return Operator.Greater;
            case var op when op == OperatorDTO.GreaterOrEqual:
                return Operator.GreaterOrEqual;
            default:
                throw new Exception($"Operator {dto} not supported.");
        }
    }

    public OperatorDTO ToDTO(Operator entity)
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
