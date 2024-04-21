using Domain.DTOs.Dossiers.CreateDossier;
using Domain.DTOs.Persons;

namespace Application.Dossiers.Commands.CreateDossier.Handlers;

public class CreateDossierHandler(ICommandsRepository commandsRepository, IMapper mapper)
    : Handler<CreateDossierInstance>
{
    public override async Task Process(CreateDossierInstance toHandle, CancellationToken cancellationToken)
    {
        var plaintiff = await AddOrUpdatePersonByDocsAsync(toHandle.Request.Plaintiff, cancellationToken);
        var defendant = await AddOrUpdatePersonByDocsAsync(toHandle.Request.Defendant, cancellationToken);

        var dossier = mapper.Map<Dossier>(toHandle.Request);
        dossier.Plaintiff = plaintiff;
        dossier.Defendant = defendant;

        await commandsRepository.Dossiers.AddAsync(dossier, cancellationToken);

        await commandsRepository.SaveChangesAsync(cancellationToken);

        toHandle.Response = new CreateDossierResponse(dossier.Id);
    }

    private async Task<Person> AddOrUpdatePersonByDocsAsync(PersonDto personDto, CancellationToken cancellationToken)
    {
        var person = await commandsRepository.Persons
            .FirstOrDefaultAsync(s =>
                s.DocumentType == personDto.DocumentType &&
                s.DocumentNumber == personDto.DocumentNumber, cancellationToken);

        if (person is null)
        {
            person = mapper.Map<Person>(personDto);
            await commandsRepository.Persons.AddAsync(person, cancellationToken);
        }
        else
            person = mapper.Map(personDto, person);

        return person;
    }
}