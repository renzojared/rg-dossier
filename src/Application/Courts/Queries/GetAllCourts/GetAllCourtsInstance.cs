using Domain.DTOs.Courts;

namespace Application.Courts.Queries.GetAllCourts;

public class GetAllCourtsInstance
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Court, NameSelectDto>().ReverseMap();
        }
    }
}