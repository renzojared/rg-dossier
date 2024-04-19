namespace Domain.ValueObjects;

public static class Endpoints
{
    private const string Api = $"{nameof(Api.ToLower)}";
    private const string Dossier = $"{nameof(Dossier.ToLower)}";
    private const string Create = $"{nameof(Create.ToLower)}";
    public const string CreateDossier = $"{Api}/{Dossier}/{Create}";
}