using Domain.DTOs.Persons.GetAllPersons;

namespace Gateways.Implementations.Persons;

public interface IGetAllPersonsGateway
{
    Task<GetAllPersonsResponse> GetAll();
}