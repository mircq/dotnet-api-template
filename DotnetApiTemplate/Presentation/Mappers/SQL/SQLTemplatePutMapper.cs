using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs.SQL;
using Domain.Entities;
namespace Presentation.Mappers.SQL;


[Mapper]
public partial class SQLTemplatePutMapper
{
    public partial SQLTemplatePutOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(SQLTemplatePutInputDTO dto);
}
