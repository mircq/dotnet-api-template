using System;

namespace Domain.Entities;

public class PatchEntity
{
    public string op { get; set; }

    public string path { get; set; }

    public string value { get; set; }
}
