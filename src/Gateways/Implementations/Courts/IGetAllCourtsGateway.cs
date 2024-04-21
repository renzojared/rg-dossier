using Domain.DTOs.Courts.GetAllCourts;

namespace Gateways.Implementations.Courts;

public interface IGetAllCourtsGateway
{
    Task<GetAllCourtsResponse> GetAll();
}