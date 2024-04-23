using Domain.DTOs.Dossiers.GetDossierReport;

namespace Application.Dossiers.Queries.GetDossierReport;

internal class GetDossierReportUseCase(
    IOutputPort<GetDossierReportResponse> outputPort,
    IQueriesRepository queriesRepository) : IInputPort<GetDossierReportInstance>
{
    public async Task Execute(GetDossierReportInstance instance, CancellationToken cancellationToken)
    {
        try
        {
            var dossiers = await queriesRepository.Dossiers
                .Include(s => s.Responsible)
                .ThenInclude(s => s.Person)
                .Include(s => s.DossierPersons)
                .ThenInclude(s => s.Person)
                .Where(s =>
                    (instance.OverallProcessId == 0 || s.OverallProcessId == instance.OverallProcessId) &&
                    (instance.MatterId == 0 || s.MatterId == instance.MatterId) &&
                    (instance.CourtId == 0 || s.CourtId == instance.CourtId) &&
                    (instance.VolumeNumber == 0 || s.VolumeNumber == instance.VolumeNumber) &&
                    (instance.InternalCode == string.Empty || s.InternalCode == instance.InternalCode) &&
                    (instance.NumberDossier == 0 || s.Number == instance.NumberDossier) &&
                    (instance.StartDate.Date == new DateTime(1900, 1, 1) || s.StartDate.Date >= instance.StartDate.Date) &&
                    (instance.EndDate.Date == new DateTime(2500, 1, 1) || !s.EndDate.HasValue || s.EndDate.Value.Date <= instance.EndDate.Date) &&
                    (instance.Year == 0 || s.Year == instance.Year) &&
                    (instance.DossierState == 0 || s.State == instance.DossierState) &&
                    (instance.DossierPersonType == 0 ||
                     (
                         instance.DossierPersonType.IsAllow() &&
                         s.DossierPersons
                             .Any(dp =>
                                 dp.DossierPersonType == instance.DossierPersonType &&
                                 (instance.DocumentType == 0 || instance.DocumentType == dp.Person.DocumentType) &&
                                 (instance.DocumentNumber == string.Empty || instance.DocumentNumber == dp.Person.DocumentNumber) &&
                                 (instance.Names == string.Empty || dp.Person.OnlyNames.Contains(instance.Names)) &&
                                 (instance.Surnames == string.Empty || dp.Person.OnlySurnames.Contains(instance.Surnames)))) ||
                     (
                         !instance.DossierPersonType.IsAllow() &&
                         (instance.DocumentType == 0 || instance.DocumentType == s.Responsible.Person.DocumentType) &&
                         (instance.DocumentNumber == string.Empty || instance.DocumentNumber == s.Responsible.Person.DocumentNumber) &&
                         (instance.Names == string.Empty || s.Responsible.Person.OnlyNames.Contains(instance.Names)) &&
                         (instance.Surnames == string.Empty || s.Responsible.Person.OnlySurnames.Contains(instance.Surnames))
                     )
                    )).ToListAsync(cancellationToken);

            var result = from d in dossiers
                join op in queriesRepository.OverallProcesses on d.OverallProcessId equals op.Id
                join m in queriesRepository.Matters on d.MatterId equals m.Id into me
                from m in me.DefaultIfEmpty()
                select new ReportDossierResultDto(
                    d.Id,
                    d.State,
                    d.InternalCode,
                    d.Number,
                    op.Description,
                    m?.Description,
                    d.Responsible.Person.FullName,
                    d.DossierPersons
                        .Where(s => s.DossierPersonType == DossierPersonType.Plaintiff)
                        .Select(s => s.Person.FullName)
                        .FirstOrDefault(),
                    d.DossierPersons
                        .Where(s => s.DossierPersonType == DossierPersonType.Defendant)
                        .Select(s => s.Person.FullName)
                        .FirstOrDefault());

            await outputPort.Default(new GetDossierReportResponse(result));
        }
        catch (Exception e)
        {
            await outputPort.Error(e);
        }
    }
}