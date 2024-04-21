using Application.Persons.Queries.GetAllPersons;
using Domain.DTOs.Persons.GetAllPersons;

namespace WebApi.Persons.GetAllPersons;

[Route(Endpoints.GetAllPersons)]
[ApiController]
public class PersonController(
    IInputPort<GetAllPersonsInstance> inputPort,
    IOutputPort<GetAllPersonsResponse> outputPort) : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(GetAllPersonsResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        await inputPort.Execute(new GetAllPersonsInstance(), cancellationToken);
        return ((Presenter)outputPort).Result;
    }
}