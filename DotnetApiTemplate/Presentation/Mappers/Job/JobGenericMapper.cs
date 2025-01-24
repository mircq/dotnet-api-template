using Domain.Entities;
using Presentation.DTOs.Job;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Job;

[Mapper]
public partial class JobGenericMapper
{
    public partial JobEntity ToEntity(JobInputDTO dto);
}
