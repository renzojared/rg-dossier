namespace Domain.Entities;

public class Dossier : BaseAuditableEntity
{
    public int? MatterId { get; set; }
    public int OverallProcessId { get; set; }
    public DossierState State { get; set; }
    public string InternalCode { get; set; }
    public int Number { get; set; }
    public int Year { get; set; }
    public int? VolumeNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int CourtId { get; set; }
    public Court Court { get; set; }
    public int ResponsibleId { get; set; }
    public Responsible Responsible { get; set; }
    public HashSet<DossierPerson> DossierPersons { get; } = [];
}