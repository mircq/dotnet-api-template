using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs.SQL;
using Domain.Entities;
namespace Presentation.Mappers.SQL;


[Mapper]
public partial class SQLTemplatePostMapper
{
    public partial SQLTemplatePostOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(SQLTemplatePostInputDTO dto);
}
