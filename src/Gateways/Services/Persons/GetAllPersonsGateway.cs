using Domain.DTOs.Persons.GetAllPersons;
using Gateways.Implementations.Persons;

namespace Gateways.Services.Persons;

public class GetAllPersonsGateway : IGetAllPersonsGateway
{
    private readonly IHttpClientFactory clientFactory;

    public GetAllPersonsGateway(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    public async Task<GetAllPersonsResponse> GetAll()
    {
        var client = clientFactory
            .CreateClient(nameof(WebApiOptions));
        
        var response = await client
            .GetAsync(Endpoints.GetAllPersons);

        return await response.Content.ReadFromJsonAsync<GetAllPersonsResponse>();
    }
}