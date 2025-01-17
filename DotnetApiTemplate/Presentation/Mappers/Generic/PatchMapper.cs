using Domain.Entities;
using Presentation.DTOs.Generic;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Generic;

[Mapper]
public partial class PatchMapper
{
    public partial PatchDTO ToDTO(PatchEntity entity);

    public partial PatchEntity ToEntity(PatchDTO dto);
}
