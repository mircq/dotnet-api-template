using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Presentation.DTOs.Generic;

namespace Presentation.Mappers.Generic;

public class PatchMapper
{
    public JsonPatchDocument ToEntity(List<PatchDTO> dto)
    {
        JsonPatchDocument patchDocument = new JsonPatchDocument();

        foreach(var patch in dto)
        {
            patchDocument.Operations.Add(new Operation
            {
                op = patch.op,
                path = patch.path,
                value = patch.value
            });
        }
        
        return patchDocument;
    }
}
