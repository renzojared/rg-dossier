using Domain.DTOs.Dossiers.GetDossierReport;

namespace WebApi.Dossiers.GetDossierReport;

internal class GetDossierReportPresenter : Presenter, IOutputPort<GetDossierReportResponse>
{
    public Task Default(GetDossierReportResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}