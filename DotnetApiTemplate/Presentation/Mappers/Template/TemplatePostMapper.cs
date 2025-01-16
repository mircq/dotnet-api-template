using System;
using Riok.Mapperly.Abstractions;
using Presentation.DTOs;
using Domain.Entities;
namespace Presentation.Mappers;


[Mapper]
public partial class TemplatePostMapper
{
    public partial TemplatePostOutputDTO ToDTO(TemplateEntity entity);

    public partial TemplateEntity ToEntity(TemplatePostInputDTO dto);
}
