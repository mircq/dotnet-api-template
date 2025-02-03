namespace Presentation.DTOs.Generic;

public class FilterDTO
{
    public string SortBy { get; set; }

    public string SortOrder { get; set; }

    public uint PageNumber {get; set;}

    public uint PageSize {get; set;}

    public List<ConditionDTO> filters { get; set; } = []; 
}