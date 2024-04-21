namespace Application.Matters.Queries.GetAllMatters;

public class GetAllMattersInstance
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Matter, SelectDto>().ReverseMap();
        }
    }
}