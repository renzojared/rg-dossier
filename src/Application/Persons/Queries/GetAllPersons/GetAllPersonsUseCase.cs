using Domain.DTOs.Persons.GetAllPersons;

namespace Application.Persons.Queries.GetAllPersons;

internal class GetAllPersonsUseCase(
    IQueriesRepository queriesRepository,
    IOutputPort<GetAllPersonsResponse> outputPort,
    IMapper mapper) : IInputPort<GetAllPersonsInstance>
{
    public async Task Execute(GetAllPersonsInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var persons = await queriesRepository.Persons
                .ToListAsync(cancellationToken);
            var mapPersons = mapper.Map<List<FullNameSelectDto>>(persons);
            await outputPort.Default(new GetAllPersonsResponse(mapPersons));
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}