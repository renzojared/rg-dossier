using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace WebApi.OverallProcesses.GetAllOverallProcesses;

internal class GetAllOverallProcessesPresenter : Presenter, IOutputPort<List<GetAllOverallProcessesResponse>>
{
    public Task Default(List<GetAllOverallProcessesResponse>? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;    }
}