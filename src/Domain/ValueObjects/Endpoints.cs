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
    //Action
    public const string CreateDossier = $"{Api}/{Dossier}/{Create}";
    public const string GetAllOverallProcess = $"{Api}/{OverallProcess}/{GetAll}";
}