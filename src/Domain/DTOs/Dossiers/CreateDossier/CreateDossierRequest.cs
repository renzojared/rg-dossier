using Domain.DTOs.Common;

namespace Domain.DTOs.Dossiers.CreateDossier;

public record CreateDossierRequest(
    int OverallProcessId,
    int MatterId,
    string InternalCode,
    int Number,
    int Year,
    int VolumeNumber,
    int CourtId,
    int ResponsibleId,
    PersonDto Plaintiff,
    PersonDto Defendant,
    DossierState DossierState,
    DateTime StartDate);