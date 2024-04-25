using Domain.DTOs.Dossiers.ReportDossier;
using Views.ViewModels.Dossier;

namespace Views.Components.Dossier;

public partial class ReportDossierComp
{
    [Parameter]
    [EditorRequired]
    public ReportDossierVm ReportDossier { get; set; }

    public IEnumerable<ReportDossierResultDto> ReportDossierResultDtos { get; set; } = [];
    private bool _gettingReport = false;

    private async Task GetReport()
    {
        _gettingReport = true;
        try
        {
            var result = await ReportDossier.GetReportAsync();
            ReportDossierResultDtos = result.reportDossierResultDtos;
            StateHasChanged();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        _gettingReport = false;
    }

    private void ResetValues()
    {
        ReportDossier.OverallProcessId = null;
        ReportDossier.MatterId = null;
        ReportDossier.CourtId = null;
        ReportDossier.VolumeNumber = null;
        ReportDossier.InternalCode = null;
        ReportDossier.NumberDossier = null;
        ReportDossier.DossierPersonType = DossierPersonType.Responsible;
        ReportDossier.DocumentType = DocumentType.Nic;
        ReportDossier.DocumentNumber = null;
        ReportDossier.Names = null;
        ReportDossier.Surnames = null;
        ReportDossier.DateRange = new();
        ReportDossier.YearPicker = null;
        ReportDossier.DossierState = DossierState.Completed;
    }
}