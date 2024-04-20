using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace Application.OverallProcesses.Queries.GetAllOverallProcesses;

internal class GetAllOverallProcessesUseCase(
    IQueriesRepository queriesRepository,
    IOutputPort<List<GetAllOverallProcessesResponse>> outputPort,
    IMapper mapper) : IInputPort
{
    public async Task Execute(CancellationToken cancellationToken)
    {
        try
        {
            var processes = await queriesRepository.OverallProcesses
                .Include(s => s.Matters)
                .ToListAsync(cancellationToken);

            var result = mapper.Map<List<GetAllOverallProcessesResponse>>(processes);

            await outputPort.Default(result);
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}