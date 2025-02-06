namespace Domain.Entities;

public class FilterEntity
{
    public string SortField { get; set; }

    public string SortOrder { get; set; }

    public uint PageNumber {get; set;}

    public uint PageSize {get; set;}

    public List<ConditionEntity> filters { get; set; } = []; 
}