namespace Domain.ValueObjects;

public static class Endpoints
{
    private const string api = nameof(api);

    #region Entities
    private const string dossier = nameof(dossier);
    private const string overallprocess = nameof(overallprocess);
    private const string court = nameof(court);
    private const string person = nameof(person);
    #endregion

    #region Actions
    private const string create = nameof(create);
    private const string getall = nameof(getall);
    private const string report = nameof(report);
    #endregion

    #region Endpoints
    public const string CreateDossier = $"{api}/{dossier}/{create}";
    public const string GetAllOverallProcess = $"{api}/{overallprocess}/{getall}";
    public const string GetAllCourts = $"{api}/{court}/{getall}";
    public const string GetAllPersons = $"{api}/{person}/{getall}";
    public const string GetReportDossier = $"{api}/{dossier}/{report}";
    #endregion
}