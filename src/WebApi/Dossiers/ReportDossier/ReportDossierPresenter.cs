using Domain.DTOs.Dossiers.ReportDossier;

namespace WebApi.Dossiers.ReportDossier;

internal class ReportDossierPresenter : Presenter, IOutputPort<ReportDossierResponse>
{
    public Task Default(ReportDossierResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}