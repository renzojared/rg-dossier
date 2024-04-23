namespace Domain.DTOs.Dossiers.GetDossierReport;

public record GetDossierReportRequest(
    DossierReportFilterGroup? FilterGroup,
    DossierReportFilterDocument? FilterDocument,
    DossierReportFilerPerson? FilerPerson,
    DossierReportFilterDate? FilterDate);

public record DossierReportFilterGroup(
    int? OverallProcessId,
    int? MatterId,
    int? CourtId,
    int? VolumeNumber);

public record DossierReportFilterDocument(
    string? InternalCode,
    int? NumberDossier);

public record DossierReportFilerPerson(
    DossierPersonType? DossierPersonType,
    DocumentType? DocumentType,
    string? DocumentNumber,
    string? Names,
    string? Surnames);

public record DossierReportFilterDate(
    DateTime StartDate,
    DateTime EndDate,
    int Year,
    DossierState DossierState);