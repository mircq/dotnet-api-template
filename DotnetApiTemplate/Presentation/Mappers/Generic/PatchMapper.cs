using Domain.Entities;
using Domain.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Presentation.DTOs.Generic;

namespace Presentation.Mappers.Generic;

public class PatchMapper
{
    public JsonPatchDocument ToEntity(List<PatchDTO> dto)
    {
        JsonPatchDocument patchDocument = new();

        foreach(var patch in dto)
        {
            patchDocument.Operations.Add(new Operation
            {
                op = patch.Op,
                path = patch.Path,
                value = DynamicExtractor.ExtractValue(jsonElement: patch.Value)
            });
        }
        
        return patchDocument;
    }
}
