using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs.NoSQL;
using Domain.Entities;
namespace Presentation.Mappers.NoSQL;


[Mapper]
public partial class NoSQLTemplatePostMapper
{
    public partial NoSQLTemplatePostOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(NoSQLTemplatePostInputDTO dto);
}
