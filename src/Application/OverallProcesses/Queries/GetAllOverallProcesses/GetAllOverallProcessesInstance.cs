using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace Application.OverallProcesses.Queries.GetAllOverallProcesses;

public class GetAllOverallProcessesInstance
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OverallProcess, GetAllOverallProcessesResponse>().ReverseMap();
        }
    }
}