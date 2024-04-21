using Domain.DTOs.Courts.GetAllCourts;

namespace WebApi.Courts.GetAllCourts;

public class GetAllCourtsPresenter : Presenter, IOutputPort<GetAllCourtsResponse>
{
    public Task Default(GetAllCourtsResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}