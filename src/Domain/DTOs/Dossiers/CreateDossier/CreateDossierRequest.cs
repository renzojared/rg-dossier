using Domain.DTOs.Persons;

namespace Domain.DTOs.Dossiers.CreateDossier;

public record CreateDossierRequest(
    DossierState DossierState,
    DateTime StartDate,
    int OverallProcessId,
    int MatterId,
    string InternalCode,
    int Number,
    int Year,
    int CourtId,
    int ResponsibleId,
    PersonDto Plaintiff,
    PersonDto Defendant);