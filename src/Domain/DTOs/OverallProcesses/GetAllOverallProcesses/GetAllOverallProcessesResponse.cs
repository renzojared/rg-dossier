namespace Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

public record GetAllOverallProcessesResponse(List<OverallProcessesDto> OverallProcesses);

public class OverallProcessesDto : SelectDto
{
    public List<SelectDto> Matters { get; set; } = [];
}