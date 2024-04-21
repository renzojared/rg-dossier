namespace Application.Persons.Queries.GetAllPersons;

public class GetAllPersonsInstance
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Person, FullNameSelectDto>().ReverseMap();
        }
    }
}