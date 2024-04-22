namespace Domain.Enums;

[Description("Estado expediente")]
public enum DossierState
{
    [Description("Completado")]
    Completed = 1,
    [Description("Definido")]
    Defined = 2
}