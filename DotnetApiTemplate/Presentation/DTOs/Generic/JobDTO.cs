namespace Presentation.DTOs.Generic;

public class JobDTO
{
    public string FunctionName { get; set; }

    public List<object> Args { get; set; }

    public Dictionary<string, object> Kwargs { get; set; }
}
