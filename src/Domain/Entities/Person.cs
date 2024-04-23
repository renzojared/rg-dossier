namespace Domain.Entities;

public class Person : BaseAuditableEntity
{
    public DocumentType DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public string BusinessName { get; set; }
    public HashSet<DossierPerson> DossierPersons { get; } = [];
    public string OnlyNames => $"{FirstName} {SecondName}";
    public string OnlySurnames => $"{PaternalSurname} {MaternalSurname}";
    public string FullName => $"{FirstName} {SecondName} {PaternalSurname} {MaternalSurname}";
}