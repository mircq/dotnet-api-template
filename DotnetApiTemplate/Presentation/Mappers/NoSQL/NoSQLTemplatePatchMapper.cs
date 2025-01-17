using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs.NoSQL;
using Presentation.DTOs.SQL;

namespace Presentation.Mappers.NoSQL;

[Mapper]
public partial class NoSQLTemplatePatchMapper
{
    public partial NoSQLTemplatePatchOutputDTO ToDTO(TemplateEntity entity);

}

