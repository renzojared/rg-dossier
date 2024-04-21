using Domain.DTOs.Persons.GetAllPersons;

namespace WebApi.Persons.GetAllPersons;

internal class GetAllPersonsPresenter : Presenter, IOutputPort<GetAllPersonsResponse>
{
    public Task Default(GetAllPersonsResponse? response)
    {
        Result = Results.Ok(response);
        return Task.CompletedTask;
    }
}