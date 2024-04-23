using Application.Dossiers.Queries.ReportDossier;
using Domain.DTOs.Dossiers.ReportDossier;

namespace WebApi.Dossiers.ReportDossier;
[Route(Endpoints.GetReportDossier)]
[ApiController]
public class DossierController(
    IInputPort<ReportDossierInstance> inputPort,
    IOutputPort<ReportDossierResponse> outputPort): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ReportDossierResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> GetReport([FromBody] ReportDossierRequest request,
        CancellationToken cancellationToken)
    {
        await inputPort.Execute(new ReportDossierInstance(request), cancellationToken);
        return ((Presenter)outputPort).Result;
    }
}