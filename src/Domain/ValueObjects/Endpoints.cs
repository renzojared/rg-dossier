namespace Domain.ValueObjects;

public static class Endpoints
{
    private const string Api = $"{nameof(Api)}";
    //Common
    private const string Create = $"{nameof(Create)}";
    private const string GetAll = $"{nameof(GetAll)}";
    //Entity
    private const string Dossier = $"{nameof(Dossier)}";
    private const string OverallProcess = $"{nameof(OverallProcess)}";
    private const string Court = $"{nameof(Court)}";
    private const string Person = $"{nameof(Person)}";
    //Action
    public const string CreateDossier = $"{Api}/{Dossier}/{Create}";
    public const string GetAllOverallProcess = $"{Api}/{OverallProcess}/{GetAll}";
    public const string GetAllCourts = $"{Api}/{Court}/{GetAll}";
    public const string GetAllPersons = $"{Api}/{Person}/{GetAll}";
}