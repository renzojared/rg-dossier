using Domain.DTOs.Persons;

namespace Views.ViewModels.Common;

public class PersonVm
{
    public DocumentType DocumentType { get; set; } = DocumentType.Nic;
    public string DocumentNumber { get; set; }
    public string Names { get; set; }
    public string Surnames { get; set; }

    private class Mapping : Profile
    {
        public Mapping() => CreateMap<PersonVm, PersonDto>().ReverseMap();
    }
}