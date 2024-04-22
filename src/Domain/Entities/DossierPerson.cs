namespace Domain.Entities;

public class DossierPerson : BaseAuditableEntity
{
    public int DossierId { get; set; }
    public Dossier Dossier { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

    public DossierPersonType DossierPersonType { get; set; }
}