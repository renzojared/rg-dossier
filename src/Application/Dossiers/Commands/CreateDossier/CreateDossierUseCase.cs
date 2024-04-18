using Application.Dossiers.Commands.CreateDossier.Handlers;
using Domain.DTOs.Dossiers.CreateDossier;

namespace Application.Dossiers.Commands.CreateDossier;

internal class CreateDossierUseCase : IInputPort<CreateDossierInstance>
{
    private readonly IOutputPort<CreateDossierResponse?> _outputPort;
    private readonly CreateDossierHandler _createDossierHandler;

    public CreateDossierUseCase(IOutputPort<CreateDossierResponse?> outputPort, CreateDossierHandler createDossierHandler)
    {
        _outputPort = outputPort;
        _createDossierHandler = createDossierHandler;
    }

    public async Task Execute(CreateDossierInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            await _createDossierHandler.Process(instance, cancellationToken);
            await _outputPort.Default(instance.Response);
        }
        catch (Exception e)
        {
            await _outputPort.Error(e);
        }
    }
}