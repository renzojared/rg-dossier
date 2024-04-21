using Domain.DTOs.Courts;
using Domain.DTOs.Courts.GetAllCourts;

namespace Application.Courts.Queries.GetAllCourts;

internal class GetAllCourtsUserCase(
    IQueriesRepository queriesRepository,
    IOutputPort<GetAllCourtsResponse> outputPort,
    IMapper mapper) : IInputPort<GetAllCourtsInstance>
{
    public async Task Execute(GetAllCourtsInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var courts = await queriesRepository.Courts.ToListAsync(cancellationToken);
            var mapCourts = mapper.Map<List<NameSelectDto>>(courts);
            await outputPort.Default(new GetAllCourtsResponse(mapCourts));
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}