namespace Domain.Enums;

[Description("Tipo persona expediente")]
public enum DossierPersonType
{
    [Description("Demandante")]
    Plaintiff = 1,
    [Description("Demandado")]
    Defendant = 2,
    [Description("Responsable")] //Restringido solo para busquedas
    Responsible = 3
}