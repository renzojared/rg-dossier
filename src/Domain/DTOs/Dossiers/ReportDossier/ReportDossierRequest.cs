namespace Domain.DTOs.Dossiers.ReportDossier;

public record ReportDossierRequest(
    ReportDossierFilterGroup? FilterGroup,
    ReportDossierFilterDocument? FilterDocument,
    ReportDossierFilerPerson? FilerPerson,
    ReportDossierFilterDate? FilterDate);

public record ReportDossierFilterGroup(
    int? OverallProcessId,
    int? MatterId,
    int? CourtId,
    int? VolumeNumber);

public record ReportDossierFilterDocument(
    string? InternalCode,
    int? NumberDossier);

public record ReportDossierFilerPerson(
    DossierPersonType? DossierPersonType,
    DocumentType? DocumentType,
    string? DocumentNumber,
    string? Names,
    string? Surnames);

public record ReportDossierFilterDate(
    DateTime StartDate,
    DateTime EndDate,
    int Year,
    DossierState DossierState);