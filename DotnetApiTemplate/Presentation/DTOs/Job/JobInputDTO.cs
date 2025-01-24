namespace Presentation.DTOs.Job;

public class JobInputDTO
{
    public string FunctionName { get; set; }

    public List<object> Args { get; set; }

    public Dictionary<string, object> Kwargs { get; set; }
}
