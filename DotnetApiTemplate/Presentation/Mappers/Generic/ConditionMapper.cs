using System.Reflection.Metadata;
using Domain.Entities;
using Presentation.DTOs.Generic;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Generic;

[Mapper]
public partial class ConditionMapper
{
    public partial ConditionDTO ToDTO(ConditionEntity entity);

    public partial ConditionEntity ToEntity(ConditionDTO dto);

    private Operator ToOperator(OperatorDTO dto) => new OperatorMapper().ToEntity(dto: dto);

    private OperatorDTO ToOperatorDTO(Operator entity) => new OperatorMapper().ToDTO(entity: entity);
}
