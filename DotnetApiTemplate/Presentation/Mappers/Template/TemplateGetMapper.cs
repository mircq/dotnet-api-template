using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs;

namespace Presentation.Mappers;

[Mapper]
public partial class TemplateGetMapper
{
    public partial TemplateGetOutputDTO ToDTO(TemplateEntity entity);

}

