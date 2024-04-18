namespace Domain.Entities;

public class Dossier : BaseAuditableEntity
{
    public int MatterId { get; set; }
    public Matter Matter { get; set; }

    public DossierState State { get; set; }
    public string InternalCode { get; set; }
    public int Number { get; set; }
    public int Year { get; set; }
    public int VolumeNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int CourtId { get; set; }
    public Court Court { get; set; }

    public int PlaintiffId { get; set; }
    public Person Plaintiff { get; set; }

    public int DefendantId { get; set; }
    public Person Defendant { get; set; }
    
    public int ResponsibleId { get; set; }
    public Person Responsible { get; set; }
}