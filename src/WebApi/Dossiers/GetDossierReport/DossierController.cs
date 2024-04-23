using Application.Dossiers.Queries.GetDossierReport;
using Domain.DTOs.Dossiers.GetDossierReport;

namespace WebApi.Dossiers.GetDossierReport;
[Route(Endpoints.GetReportDossier)]
[ApiController]
public class DossierController(
    IInputPort<GetDossierReportInstance> inputPort,
    IOutputPort<GetDossierReportResponse> outputPort): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(GetDossierReportResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> GetReport([FromBody] GetDossierReportRequest request,
        CancellationToken cancellationToken)
    {
        await inputPort.Execute(new GetDossierReportInstance(request), cancellationToken);
        return ((Presenter)outputPort).Result;
    }
}