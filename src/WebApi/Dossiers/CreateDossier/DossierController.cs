using Application.Dossiers.Commands.CreateDossier;
using Domain.DTOs.Dossiers.CreateDossier;
using Domain.ValueObjects;

namespace WebApi.Dossiers.CreateDossier;

[Route(Endpoints.CreateDossier)]
[ApiController]
public class DossierController(
    IInputPort<CreateDossierInstance> inputPort,
    IOutputPort<CreateDossierResponse> outputPort) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateDossierResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> Create([FromBody] CreateDossierRequest request, CancellationToken cancellationToken)
    {
        await inputPort.Execute(new CreateDossierInstance(request), cancellationToken);
        return ((Presenter)outputPort).Result;
    }
}