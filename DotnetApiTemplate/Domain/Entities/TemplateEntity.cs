using System;

namespace Domain.Entities;

public class TemplateEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public int Value { get; set; }
}
