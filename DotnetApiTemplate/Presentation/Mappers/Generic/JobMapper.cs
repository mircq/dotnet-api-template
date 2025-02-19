using Domain.Entities;
using Presentation.DTOs.Generic;
using Presentation.DTOs.Job;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Generic;

[Mapper]
public partial class JobMapper
{
    public partial JobEntity ToEntity(JobDTO dto);
}
