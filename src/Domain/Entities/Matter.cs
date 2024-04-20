namespace Domain.Entities;

public class Matter : BaseAuditableEntity
{
    public string Description { get; set; }
    public int? OverallProcessId { get; set; }
    public OverallProcess? OverallProcess { get; set; }
    public HashSet<Dossier> Dossiers { get; set; } = [];
}