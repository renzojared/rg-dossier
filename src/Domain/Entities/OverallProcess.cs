namespace Domain.Entities;

public class OverallProcess : BaseAuditableEntity
{
    public string Description { get; set; }
    public HashSet<Matter> Matters { get; set; } = [];
}