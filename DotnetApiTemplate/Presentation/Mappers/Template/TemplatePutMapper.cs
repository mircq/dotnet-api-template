using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs;
using Domain.Entities;
namespace Presentation.Mappers;


[Mapper]
public partial class TemplatePutMapper
{
    public partial TemplatePutOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(TemplatePutInputDTO dto);
}
