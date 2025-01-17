using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs.NoSQL;

namespace Presentation.Mappers.NoSQL;

[Mapper]
public partial class NoSQLTemplateGetMapper
{
    public partial NoSQLTemplateGetOutputDTO ToDTO(TemplateEntity entity);

}

