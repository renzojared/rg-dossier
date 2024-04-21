using Domain.DTOs.OverallProcesses.GetAllOverallProcesses;

namespace Gateways.Implementations;

public interface IGetAllOverallProcessesGateway
{
    Task<GetAllOverallProcessesResponse> GetAll();
}