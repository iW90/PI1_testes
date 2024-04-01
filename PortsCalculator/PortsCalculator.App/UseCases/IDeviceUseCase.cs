using PortsCalculator.App.Models.Requests;
using PortsCalculator.App.Models.Responses;

namespace PortsCalculator.App.UseCases
{
    public interface IDeviceUseCase
    {
        Task<DevicesListResponse> GetAllDevices(int pageNumber, int pageSize);
        Task<DeviceResponse?> GetDeviceById(int deviceId);
        Task<DeviceResponse?> GetDeviceByName(string deviceName);
        Task AddDevice(DeviceRequest deviceRequest);
        Task UpdateDevice(int deviceId, DeviceRequest deviceRequest);
        Task DeleteDevice(int deviceId);
        PortsResponse CalculateTotalPorts(List<DeviceResponse> devices);
    }
}
