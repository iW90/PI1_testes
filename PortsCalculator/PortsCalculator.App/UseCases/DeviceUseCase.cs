using PortsCalculator.App.Models.Requests;
using PortsCalculator.App.Models.Responses;
using PortsCalculator.Infra.Repositories;
using PortsCalculator.Core.Entities;
using AutoMapper;

namespace PortsCalculator.App.UseCases
{
    public class DeviceUseCase : IDeviceUseCase
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public DeviceUseCase(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DevicesListResponse> GetAllDevices(int pageNumber, int pageSize)
        {
            var devices = await _repository.DevicesList(pageNumber, pageSize);
            var devicesListResponse = _mapper.Map<IEnumerable<Device>, List<DeviceResponse>>(devices);

            return new DevicesListResponse
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Devices = devicesListResponse
            };
        }

        public async Task<DeviceResponse?> GetDeviceById(int deviceId)
        {
            var device = await _repository.GetDeviceById(deviceId);

            if (device != null)
            {
                return _mapper.Map<Device, DeviceResponse>(device);
            }
            return null;
        }

        public async Task<DeviceResponse?> GetDeviceByName(string deviceName)
        {
            var device = await _repository.GetDeviceByName(deviceName);

            if (device != null)
            {
                return _mapper.Map<Device, DeviceResponse>(device);
            }
            return null;
        }

        public async Task AddDevice(DeviceRequest deviceRequest)
        {
            var device = _mapper.Map<DeviceRequest, Device>(deviceRequest);
            await _repository.AddDevice(device);
        }

        public async Task UpdateDevice(int deviceId, DeviceRequest deviceRequest)
        {
            var device = await _repository.GetDeviceById(deviceId);
            if (device == null)
            {
                throw new InvalidOperationException("Device not found.");
            }

            _mapper.Map(deviceRequest, device);
            await _repository.UpdateDevice(deviceId, device);
        }

        public async Task DeleteDevice(int deviceId)
        {
            await _repository.DeleteDevice(deviceId);
        }

        public PortsResponse GetTotalPorts(List<DeviceResponse> devices)
        {
            List<Device> devicesList = devices.Select(dr => _mapper.Map<DeviceResponse, Device>(dr)).ToList();

            PortsResponse totalPorts = new PortsResponse
            {
                AnalogicalInput = 0,
                AnalogicalOutput = 0,
                DigitalInput = 0,
                DigitalOutput = 0
            };

            foreach (DeviceResponse device in devices)
            {
                totalPorts.AnalogicalInput += device.AnalogicalInput;
                totalPorts.AnalogicalOutput += device.AnalogicalOutput;
                totalPorts.DigitalInput += device.DigitalInput;
                totalPorts.DigitalOutput += device.DigitalOutput;
            }

            return totalPorts;
        }
    }
}