namespace Domain.DTOs.Dossiers.GetDossierReport;

public record GetDossierReportResponse(IEnumerable<ReportDossierResultDto> reportDossierResultDtos);

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