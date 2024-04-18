namespace WebApi.Models;

public abstract class Presenter
{
    public IResult Result { get; protected set; }
    
    public virtual Task Error(Exception e)
    {
        var problems = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "Error Server",
            Title = "Ocurrió un error",
            Detail = e.InnerException?.Message ?? e.Message,
            Instance = $"{nameof(ProblemDetails)}/{e.GetType().Name}"
        };
        Result = Results.Problem(problems);
        /*Result = Results.Ok();
        Result = Results.BadRequest();
        var hola = Results.Extensions(problems);
        var res = Results.ValidationProblem(hola);
        Result = Results.ValidationProblem(problems);*/

        //TODO: Custom problemDetails
        return Task.CompletedTask;
    }
}