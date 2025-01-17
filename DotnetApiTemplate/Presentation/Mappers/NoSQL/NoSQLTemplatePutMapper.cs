using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs.NoSQL;
using Domain.Entities;
namespace Presentation.Mappers.NoSQL;


[Mapper]
public partial class NoSQLTemplatePutMapper
{
    public partial NoSQLTemplatePutOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(NoSQLTemplatePutInputDTO dto);
}
