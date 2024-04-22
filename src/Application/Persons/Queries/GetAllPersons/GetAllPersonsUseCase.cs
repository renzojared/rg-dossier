using Domain.DTOs.Persons.GetAllPersons;

namespace Application.Persons.Queries.GetAllPersons;

internal class GetAllPersonsUseCase(
    IQueriesRepository queriesRepository,
    IOutputPort<GetAllPersonsResponse> outputPort) : IInputPort<GetAllPersonsInstance>
{
    public async Task Execute(GetAllPersonsInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var persons = await queriesRepository.Responsibles
                .Include(s => s.Person)
                .Select(s => new FullNameSelectDto
                {
                    Id = s.Id,
                    FullName = s.Person.FullName,
                })
                .ToListAsync(cancellationToken);

            await outputPort.Default(new GetAllPersonsResponse(persons));
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}