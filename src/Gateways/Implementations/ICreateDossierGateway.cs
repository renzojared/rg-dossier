using Domain.DTOs.Dossiers.CreateDossier;

namespace Gateways.Implementations;

public interface ICreateDossierGateway
{
    Task<CreateDossierResponse> CreateDossierAsync(CreateDossierRequest request);
}