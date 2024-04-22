namespace Domain.Entities;

public class Responsible : BaseAuditableEntity
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public HashSet<Dossier> Dossiers { get; set; }
}