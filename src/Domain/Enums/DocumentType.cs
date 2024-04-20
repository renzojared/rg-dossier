namespace Domain.Enums;

public enum DocumentType
{
    [Description("DNI")]
    Nic = 1,
    [Description("Carnet de Extranjeria")]
    ForeignCard = 2,
    [Description("Pasaporte")]
    Passport = 3
}