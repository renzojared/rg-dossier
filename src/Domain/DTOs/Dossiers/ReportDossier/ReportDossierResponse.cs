namespace Domain.DTOs.Dossiers.ReportDossier;

public record ReportDossierResponse(IEnumerable<ReportDossierResultDto> reportDossierResultDtos);

public record ReportDossierResultDto(
    int Id,
    DossierState DossierState,
    string InternalCode,
    int NumberDossier,
    string OverallProcessDescription,
    string? MatterDescription,
    string ResponsibleFullName,
    string PlaintiffFullName,
    string DefendantFullName);