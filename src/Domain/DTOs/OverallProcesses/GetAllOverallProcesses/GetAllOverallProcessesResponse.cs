using Domain.DTOs.Matters.GetAllMatters;

namespace Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

public class GetAllOverallProcessesResponse
{
    public int Id { get; init; }
    public string Description { get; init; }
    public List<GetAllMattersResponse> Matters { get; init; } = [];
}