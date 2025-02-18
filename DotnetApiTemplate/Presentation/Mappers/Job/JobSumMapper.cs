using Domain.Entities;
using Presentation.DTOs.Job;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Job;

[Mapper]
public partial class JobSumMapper
{
    public partial JobGetTemplateOutputDTO ToDTO(SumEntity entity);
}
