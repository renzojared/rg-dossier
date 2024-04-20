using Domain.DTOs.Dossiers.CreateDossier;

namespace Views.ViewModels.Dossier;

public class CreateDossierVm(ICreateDossierGateway gateway, IMapper mapper)
{
    public CreateDossierResponse Response { get; private set; }
    public int MatterId { get; set; }
    public string InternalCode { get; set; }
    public int Number { get; set; }
    public int Year { get; set; }
    public int VolumeNumber { get; set; }
    public int CourtId { get; set; }
    public int ResponsibleId { get; set; }
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
    
    private class Mapping : Profile
    {
        public Mapping() => CreateMap<CreateDossierVm, CreateDossierRequest>().ReverseMap();
    }
}