using Domain.DTOs.Matters.GetAllMatters;

namespace Application.Matters.Queries.GetAllMatters;

public class GetAllMattersInstance
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Matter, GetAllMattersResponse>().ReverseMap();
        }
    }
}