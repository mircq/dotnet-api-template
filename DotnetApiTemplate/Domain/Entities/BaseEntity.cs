namespace Domain.Entities;

public class BaseEntity
{

    public string Tenant { get; set; }

    public string Group { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }
}
