using Domain.DTOs.Courts;
using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;
using Microsoft.AspNetCore.Components.Web;
using Views.ViewModels.Dossier;

namespace Views.Components.Dossier;

public partial class CreateDossierComp
{
    [Parameter]
    public CreateDossierVm Dossier { get; set; }
    public List<OverallProcessesDto> OverallProcesses { get; set; } = [];
    public List<NameSelectDto> Courts { get; set; } = [];
    public List<FullNameSelectDto> Responsibles { get; set; } = [];
    public List<SelectDto> MattersToDisplay { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var processes = await Dossier.GetAllProcesses();
            OverallProcesses = processes.OverallProcesses;

            var courts = await Dossier.GetAllCourts();
            Courts = courts.Courts;

            var responsibles = await Dossier.GetAllPersons();
            Responsibles = responsibles.Persons;
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