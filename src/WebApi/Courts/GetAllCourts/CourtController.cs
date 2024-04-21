using Application.Courts.Queries.GetAllCourts;
using Domain.DTOs.Courts.GetAllCourts;

namespace WebApi.Courts.GetAllCourts;

[Route(Endpoints.GetAllCourts)]
[ApiController]
public class CourtController(IInputPort<GetAllCourtsInstance> inputPort, IOutputPort<GetAllCourtsResponse> outputPort) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetAllCourtsResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        await inputPort.Execute(new GetAllCourtsInstance(), cancellationToken);
        return ((Presenter)outputPort).Result;
    }
}