using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;
using Views.ViewModels.Dossier;

namespace Views.Components.Dossier;

public partial class CreateDossierComp
{
    [Parameter]
    [EditorRequired]
    public CreateDossierVm Dossier { get; set; }
    public List<OverallProcessesDto> OverallProcesses { get; set; } = [];
    public List<NameSelectDto> Courts { get; set; } = [];
    public IEnumerable<FullNameSelectDto> Responsibles { get; set; } = [];
    public List<SelectDto> MattersToDisplay { get; set; } = [];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            var processes = await Dossier.GetAllProcesses();
            OverallProcesses = processes.OverallProcesses;

            var courts = await Dossier.GetAllCourts();
            Courts = courts.Courts;

            var responsibles = await Dossier.GetAllPersons();

            Responsibles = responsibles.Persons
                .Select(s => new FullNameSelectDto { FullName = $"Dr. {s.FullName}", Id = s.Id });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void SetMatters(int? overallProcessId)
    {
        Dossier.OverallProcessId = overallProcessId;
        Dossier.MatterId = null;
        MattersToDisplay.Clear();

        var matters = OverallProcesses.FirstOrDefault(s => s.Id == overallProcessId).Matters ?? [];
        
        if (matters.Count != 0)
            MattersToDisplay.AddRange(matters);

        StateHasChanged();
    }

}