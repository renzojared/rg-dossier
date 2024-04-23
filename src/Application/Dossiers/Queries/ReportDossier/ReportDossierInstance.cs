using Domain.DTOs.Dossiers.ReportDossier;

namespace Application.Dossiers.Queries.ReportDossier;

public class ReportDossierInstance
{
    public int OverallProcessId { get; set; }
    public int MatterId { get; set; }
    public int CourtId { get; set; }
    public int VolumeNumber { get; set; }
    
    public string InternalCode { get; set; }
    public int NumberDossier { get; set; }
    
    public DossierPersonType DossierPersonType { get; set; }
    public DocumentType DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string Names { get; set; }
    public string Surnames { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Year { get; set; }
    public DossierState DossierState { get; set; }
    
    public ReportDossierRequest Request { get; private set; }

    public ReportDossierInstance(ReportDossierRequest request)
    {
        OverallProcessId = request.FilterGroup?.OverallProcessId ?? 0;
        MatterId = request.FilterGroup?.MatterId ?? 0;
        CourtId = request.FilterGroup?.CourtId ?? 0;
        VolumeNumber = request.FilterGroup?.VolumeNumber ?? 0;

        InternalCode = request.FilterDocument?.InternalCode ?? string.Empty;
        NumberDossier = request.FilterDocument?.NumberDossier ?? 0;

        DossierPersonType = request.FilerPerson?.DossierPersonType ?? 0;
        DocumentType = request.FilerPerson?.DocumentType ?? 0;
        DocumentNumber = request.FilerPerson?.DocumentNumber ?? string.Empty;
        Names = request.FilerPerson?.Names ?? string.Empty;
        Surnames = request.FilerPerson?.Surnames ?? string.Empty;
        
        StartDate = request.FilterDate?.StartDate ?? new DateTime(1900, 1, 1);
        EndDate = request.FilterDate?.EndDate ?? new DateTime(2500, 1, 1);
        Year = request.FilterDate?.Year ?? 0;
        DossierState = request.FilterDate?.DossierState ?? 0;
    }
}