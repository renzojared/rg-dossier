using Domain.DTOs.Dossiers.CreateDossier;

namespace WebApi.Dossiers.CreateDossier;

public class CreateDossierPresenter : Presenter, IOutputPort<CreateDossierResponse> 
{
    public Task Default(CreateDossierResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}