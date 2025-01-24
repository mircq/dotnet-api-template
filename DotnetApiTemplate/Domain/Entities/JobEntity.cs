namespace Domain.Entities;

public class JobEntity
{
    public string FunctionName { get; set; }

    public List<object> Args { get; set; } = new List<object>();

    public Dictionary<string, object> Kwargs { get; set; } = new Dictionary<string, object>();
}
