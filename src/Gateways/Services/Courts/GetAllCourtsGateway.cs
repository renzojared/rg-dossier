using Domain.DTOs.Courts.GetAllCourts;
using Gateways.Implementations.Courts;

namespace Gateways.Services.Courts;

internal class GetAllCourtsGateway(IHttpClientFactory clientFactory) : IGetAllCourtsGateway
{
    public async Task<GetAllCourtsResponse> GetAll()
    {
        var client = clientFactory
            .CreateClient(nameof(WebApiOptions));
        
        var response = await client
            .GetAsync(Endpoints.GetAllCourts);

        return await response.Content.ReadFromJsonAsync<GetAllCourtsResponse>();
    }
}