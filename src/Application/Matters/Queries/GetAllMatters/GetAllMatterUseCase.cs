using Domain.DTOs.Matters.GetAllMatters;

namespace Application.Matters.Queries.GetAllMatters;

internal class GetAllMatterUseCase(
    IQueriesRepository _queriesRepository,
    IOutputPort<GetAllMattersResponse?> _outputPort) : IInputPort<GetAllMattersInstance>
{
    public async Task Execute(GetAllMattersInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var matters = await _queriesRepository.Matters.ToListAsync();

            //await _outputPort.Default(instance.Response);
        }
        catch (Exception e)
        {
            await _outputPort.Error(e);
        }
    }
}