using System;
using Riok.Mapperly.Abstractions;
using Domain.Entities;
using Presentation.DTOs;

namespace Presentation.Mappers;

[Mapper]
public partial class TemplatePatchMapper
{
    public partial TemplatePatchOutputDTO ToDTO(TemplateEntity entity);

}

