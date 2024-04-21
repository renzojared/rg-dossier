using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace Application.OverallProcesses.Queries.GetAllOverallProcesses;

internal class GetAllOverallProcessesUseCase(
    IQueriesRepository queriesRepository,
    IOutputPort<GetAllOverallProcessesResponse> outputPort,
    IMapper mapper) : IInputPort<GetAllOverallProcessesInstance>
{
    public async Task Execute(GetAllOverallProcessesInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var processes = await queriesRepository.OverallProcesses
                .Include(s => s.Matters)
                .ToListAsync(cancellationToken);

            var mapProcesses = mapper.Map<List<OverallProcessesDto>>(processes);

            await outputPort.Default(new GetAllOverallProcessesResponse(mapProcesses));
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}