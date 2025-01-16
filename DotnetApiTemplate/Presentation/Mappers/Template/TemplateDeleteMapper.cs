using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs;

namespace Presentation.Mappers;

[Mapper]
public partial class TemplateDeleteMapper
{
    public partial TemplateDeleteOutputDTO ToDTO(TemplateEntity entity);

}

