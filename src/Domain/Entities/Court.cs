namespace Domain.Entities;

public class Court : BaseAuditableEntity
{
    public string Name { get; set; }
    public HashSet<Dossier> Dossiers { get; set; } = [];
}