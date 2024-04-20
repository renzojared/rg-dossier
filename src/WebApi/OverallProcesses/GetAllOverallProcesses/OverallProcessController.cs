using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace WebApi.OverallProcesses.GetAllOverallProcesses;

[Route(Endpoints.GetAllOverallProcess)]
[ApiController]
public class OverallProcessController(IInputPort inputPort, IOutputPort<List<GetAllOverallProcessesResponse>> outputPort)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetAllOverallProcessesResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        await inputPort.Execute(cancellationToken);
        return ((Presenter)outputPort).Result;
    }

}