namespace Domain.ValueObjects;

public static class Endpoints
{
    private const string Api = $"{nameof(Api)}";
    private const string Dossier = $"{nameof(Dossier)}";
    private const string Create = $"{nameof(Create)}";
    public const string CreateDossier = $"{Api}/{Dossier}/{Create}";
}