using Domain.DTOs.Dossiers.ReportDossier;

namespace Gateways.Implementations.Dossiers;

public interface IReportDossierGateway
{
    Task<ReportDossierResponse> GetReportDossierAsync(ReportDossierRequest request);
}