using Domain.Entities;
using Presentation.DTOs.Job;
using Riok.Mapperly.Abstractions;

namespace Presentation.Mappers.Job;

[Mapper]
public partial class JobTemplateMapper
{
    public partial JobTemplateOutputDTO ToDTO(TemplateEntity entity);
}
