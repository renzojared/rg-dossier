using Domain.Entities;

namespace Domain.DTOs.Common;

public record PersonDto(DocumentType DocumentType, string DocumentNumber, string Names, string Lastnames)
{
    public static explicit operator Person(PersonDto dto)
        => new()
        {
            DocumentType = dto.DocumentType,
            DocumentNumber = dto.DocumentNumber,
            FirstName = dto.Names,
            PaternalSurname = dto.Lastnames
        };
}