using Domain.DTOs.Persons;

namespace Domain.DTOs.Dossiers.CreateDossier;

public record CreateDossierRequest(
    int? MatterId,
    int OverallProcessId,
    DossierState DossierState,
    string InternalCode,
    int Number,
    int Year,
    DateTime StartDate,
    int CourtId,
    int ResponsibleId,
    PersonDto Plaintiff,
    PersonDto Defendant);