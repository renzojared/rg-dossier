using Domain.DTOs.Common;
using Domain.DTOs.Dossiers.CreateDossier;

namespace Application.Dossiers.Commands.CreateDossier;

public class CreateDossierInstance
{
    public CreateDossierRequest? Request { get; private set; }
    public CreateDossierResponse? Response { get; set; }

    public CreateDossierInstance(CreateDossierRequest? request)
    {
        Request = request;
    }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PersonDto, Person>()
                .ForMember(s => s.FirstName, m => m.MapFrom(s => s.Names))
                .ForMember(s => s.PaternalSurname, m => m.MapFrom(s => s.Surnames))
                .ReverseMap()
                .ForMember(d => d.Names, s => s.MapFrom(s => s.FirstName))
                .ForMember(d => d.Surnames, s => s.MapFrom(s => s.PaternalSurname));

            CreateMap<CreateDossierRequest, Dossier>()
                .ForMember(d => d.State, s => s.MapFrom(d => d.DossierState));
        }
    }
}