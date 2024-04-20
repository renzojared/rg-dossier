using Views.ViewModels.Dossier;

namespace Views.Components.Dossier;

public partial class CreateDossierComp
{
    [Parameter]
    public CreateDossierVm Dossier { get; set; }
}