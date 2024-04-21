using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace WebApi.OverallProcesses.GetAllOverallProcesses;

internal class GetAllOverallProcessesPresenter : Presenter, IOutputPort<GetAllOverallProcessesResponse>
{
    public Task Default(GetAllOverallProcessesResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}