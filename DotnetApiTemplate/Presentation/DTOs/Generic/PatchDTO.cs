
using System.Text.Json;

namespace Presentation.DTOs.Generic;

public class PatchDTO
{
    public string Op { get; set; }

    public string Path { get; set; }

    public JsonElement Value { get; set; }
}
