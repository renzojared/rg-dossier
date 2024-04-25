namespace Domain.DTOs.Dossiers.ReportDossier;

public class ReportDossierRequest
{
    public ReportDossierFilterGroup? FilterGroup { get; set; }
    public ReportDossierFilterDocument? FilterDocument { get; set; }
    public ReportDossierFilterPerson? FilterPerson { get; set; }
    public ReportDossierFilterDate? FilterDate { get; set; }
}

public class ReportDossierFilterGroup
{
    public int? OverallProcessId { get; set; }
    public int? MatterId { get; set; }
    public int? CourtId { get; set; }
    public int? VolumeNumber { get; set; }
}

public class ReportDossierFilterDocument
{
    public string? InternalCode { get; set; }
    public int? NumberDossier { get; set; }
}

public class ReportDossierFilterPerson
{
    public DossierPersonType? DossierPersonType { get; set; }
    public DocumentType? DocumentType { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Names { get; set; }
    public string? Surnames { get; set; }
}

public class ReportDossierFilterDate
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Year { get; set; }
    public DossierState? DossierState { get; set; }
}
