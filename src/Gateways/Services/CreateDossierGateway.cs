using Domain.DTOs.Dossiers.CreateDossier;
namespace Gateways.Services;

internal class CreateDossierGateway : ICreateDossierGateway
{
    private readonly IHttpClientFactory clientFactory;

    public CreateDossierGateway(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    public async Task<CreateDossierResponse> CreateDossierAsync(CreateDossierRequest request)
    {
        var response = await clientFactory
            .CreateClient(nameof(WebApiOptions))
            .PostAsJsonAsync(Endpoints.CreateDossier, request);

        return await response.Content.ReadFromJsonAsync<CreateDossierResponse>();
    }
}