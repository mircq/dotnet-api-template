namespace Domain.Entities;

public class FilterEntity
{
    public string SortBy { get; set; }

    public string SortOrder { get; set; }

    public uint PageNumber {get; set;}

    public uint PageSize {get; set;}

    public List<ConditionEntity> filters { get; set; } = []; 
}