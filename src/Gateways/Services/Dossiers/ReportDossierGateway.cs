using Domain.DTOs.Dossiers.ReportDossier;
using Gateways.Implementations.Dossiers;

namespace Gateways.Services.Dossiers;

internal class ReportDossierGateway(IHttpClientFactory clientFactory) : IReportDossierGateway
{
    public async Task<ReportDossierResponse> GetReportDossierAsync(ReportDossierRequest request)
    {
        var response = await clientFactory
            .CreateClient(nameof(WebApiOptions))
            .PostAsJsonAsync(Endpoints.GetReportDossier, request);

        return await response.Content.ReadFromJsonAsync<ReportDossierResponse>();
    }
}