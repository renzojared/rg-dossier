using Domain.DTOs.Dossiers.ReportDossier;
using Gateways.Implementations.Dossiers;

namespace Views.ViewModels.Dossier;

public class ReportDossierVm(IReportDossierGateway gateway)
{
    public int? OverallProcessId { get; set; }
    public int? MatterId { get; set; }
    public int? CourtId { get; set; }
    public int? VolumeNumber { get; set; }

    public string? InternalCode { get; set; }
    public int? NumberDossier { get; set; }

    public DossierPersonType DossierPersonType { get; set; } = DossierPersonType.Responsible;
    public DocumentType DocumentType { get; set; } = DocumentType.Nic;
    public string? DocumentNumber { get; set; }
    public string? Names { get; set; }
    public string? Surnames { get; set; }

    public DateRange DateRange { get; set; } = new();
    private DateTime? StartDate => DateRange.Start;
    private DateTime? EndDate => DateRange.End;
    public DateTime? YearPicker { get; set; }
    private int? Year => YearPicker?.Year;
    public DossierState DossierState { get; set; } = DossierState.Completed;

    public async Task<ReportDossierResponse> GetReportAsync()
        => await gateway.GetReportDossierAsync(BuildRequest());

    private ReportDossierRequest BuildRequest()
        => new()
        {
            FilterGroup = new ReportDossierFilterGroup
            {
                OverallProcessId = OverallProcessId,
                MatterId = MatterId,
                CourtId = CourtId,
                VolumeNumber = VolumeNumber
            },
            FilterDocument = new ReportDossierFilterDocument
            {
                InternalCode = InternalCode,
                NumberDossier = NumberDossier
            },
            FilterPerson = new ReportDossierFilterPerson
            {
                DossierPersonType = DossierPersonType,
                DocumentType = DocumentType,
                DocumentNumber = DocumentNumber,
                Names = Names,
                Surnames = Surnames
            },
            FilterDate = new ReportDossierFilterDate
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Year = Year,
                DossierState = DossierState
            }
        };
}