using PortsCalculator.Core.Entities;

namespace PortsCalculator.Infra.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> DevicesList(int pageNumber, int pageSize);

        Task<Device?> GetDeviceById(int deviceId);

        Task<Device?> GetDeviceByName(string deviceName);

        Task<Task> AddDevice(Device device);

        Task<Task> UpdateDevice(int deviceId, Device updatedDevice);

        Task<Task> DeleteDevice(int deviceId);
    }
}
