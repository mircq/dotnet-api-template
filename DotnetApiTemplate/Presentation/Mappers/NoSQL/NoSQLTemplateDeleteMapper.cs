using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs.NoSQL;

namespace Presentation.Mappers.NoSQL;

[Mapper]
public partial class NoSQLTemplateDeleteMapper
{
    public partial NoSQLTemplateDeleteOutputDTO ToDTO(TemplateEntity entity);

}

