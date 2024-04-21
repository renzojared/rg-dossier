using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace Gateways.Services;

internal class GetAllOverallProcessesGateway : IGetAllOverallProcessesGateway
{
    private readonly IHttpClientFactory clientFactory;

    public GetAllOverallProcessesGateway(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    public async Task<GetAllOverallProcessesResponse> GetAll()
    {
        var client = clientFactory
            .CreateClient(nameof(WebApiOptions));
        
        var response = await client
            .GetAsync(Endpoints.GetAllOverallProcess);

        return await response.Content.ReadFromJsonAsync<GetAllOverallProcessesResponse>();
    }
}