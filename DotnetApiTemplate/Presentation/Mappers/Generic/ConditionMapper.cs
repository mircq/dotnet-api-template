using Domain.Entities;
using Presentation.DTOs.Generic;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Generic;

[Mapper]
public partial class ConditionMapper
{
    public partial ConditionDTO ToDTO(ConditionEntity entity);

    public partial ConditionEntity ToEntity(ConditionDTO dto);
}
