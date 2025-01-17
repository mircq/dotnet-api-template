using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs.SQL;

namespace Presentation.Mappers.SQL;

[Mapper]
public partial class SQLTemplateGetMapper
{
    public partial SQLTemplateGetOutputDTO ToDTO(TemplateEntity entity);

}

