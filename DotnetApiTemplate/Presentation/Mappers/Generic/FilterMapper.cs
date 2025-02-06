using Domain.Entities;
using Presentation.DTOs.Generic;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Generic;

[Mapper]
public partial class FilterMapper
{
    //public partial FilterDTO ToDTO(FilterEntity entity);

    public partial FilterEntity ToEntity(FilterDTO dto);

    private ConditionEntity ToConditionEntity(ConditionDTO dto) => new ConditionMapper().ToEntity(dto: dto);

    //private ConditionDTO ToConditionDTO(ConditionEntity entity) => new ConditionMapper().ToDTO(entity: entity);
}
