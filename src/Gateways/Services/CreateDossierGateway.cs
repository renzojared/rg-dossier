using Domain.DTOs.Dossiers.CreateDossier;
namespace Gateways.Services;

internal class CreateDossierGateway(IHttpClientFactory clientFactory) : ICreateDossierGateway
{
    public async Task<CreateDossierResponse> CreateDossierAsync(CreateDossierRequest request)
    {
        var response = await clientFactory
            .CreateClient(nameof(WebApiOptions))
            .PostAsJsonAsync(Endpoints.CreateDossier, request);

        return await response.Content.ReadFromJsonAsync<CreateDossierResponse>();
    }
}