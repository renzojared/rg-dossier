namespace Domain.Enums;

public enum DossierPersonType
{
    [Description("Demandante")]
    Plaintiff = 1,
    [Description("Demandado")]
    Defendant = 2
}