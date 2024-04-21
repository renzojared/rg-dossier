using Domain.DTOs.Courts.GetAllCourts;
using Domain.DTOs.Dossiers.CreateDossier;
using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;
using Domain.DTOs.Persons.GetAllPersons;
using Gateways.Implementations.Courts;
using Gateways.Implementations.Persons;

namespace Views.ViewModels.Dossier;

public class CreateDossierVm(
    ICreateDossierGateway gateway,
    IGetAllOverallProcessesGateway overallProcessesGateway,
    IGetAllCourtsGateway courtsGateway,
    IGetAllPersonsGateway personsGateway,
    IMapper mapper)
{
    public CreateDossierResponse Response { get; private set; }
    public int? OverallProcessId { get; set; }
    public int? MatterId { get; set; }
    public string InternalCode { get; set; }
    public int Number { get; set; }
    public DateTime? YearPicker { get; set; } = DateTime.Today;
    public int? Year { get => YearPicker?.Year;}
    public int? CourtId { get; set; }
    public int? ResponsibleId { get; set; }
    public PersonVm Plaintiff { get; set; } = new();
    public PersonVm Defendant { get; set; } = new();
    public DossierState DossierState { get; set; } = DossierState.Completed;
    public DateTime? StartDate { get; set; } = DateTime.Today;

    public async Task Save()
    {
        try
        {
            var request = mapper.Map<CreateDossierRequest>(this);
            Response = await gateway.CreateDossierAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<GetAllOverallProcessesResponse> GetAllProcesses()
        => await overallProcessesGateway.GetAll();

    public async Task<GetAllCourtsResponse> GetAllCourts()
        => await courtsGateway.GetAll();

    public async Task<GetAllPersonsResponse> GetAllPersons()
        => await personsGateway.GetAll();

    private class Mapping : Profile
    {
        public Mapping() => CreateMap<CreateDossierVm, CreateDossierRequest>().ReverseMap();
    }
}