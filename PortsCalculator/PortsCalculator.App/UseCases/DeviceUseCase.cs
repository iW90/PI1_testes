using PortsCalculator.App.Models.Requests;
using PortsCalculator.App.Models.Responses;
using PortsCalculator.Infra.Repositories;
using PortsCalculator.Core.Entities;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace PortsCalculator.App.UseCases
{
    public class DeviceUseCase : IDeviceUseCase
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeviceUseCase> _logger;

        public DeviceUseCase(IDeviceRepository repository, IMapper mapper, ILogger<DeviceUseCase> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DeviceResponse?> GetDeviceById(int deviceId)
        {
            try
            {
                var device = await _repository.GetDeviceById(deviceId);

                if (device != null)
                {
                    _logger.LogInformation("Id de dispositivo encontrado.");
                    return _mapper.Map<Device, DeviceResponse>(device);
                }

                _logger.LogInformation("Id de dispositivo não encontrado.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar encontrar dispositivo pelo id");
                throw;
            }
        }

        public async Task<DeviceResponse?> GetDeviceByName(string deviceName)
        {
            try
            {
                var device = await _repository.GetDeviceByName(deviceName);

                if (device != null)
                {
                    _logger.LogInformation("Nome de dispositivo encontrado.");
                    return _mapper.Map<Device, DeviceResponse>(device);
                }

                _logger.LogInformation("Nome de dispositivo não encontrado.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar encontrar dispositivo pelo nome.");
                throw;
            }
        }

        public async Task<DevicesListResponse> GetAllDevices(int pageNumber, int pageSize)
        {
            try
            {
                var devices = await _repository.DevicesList(pageNumber, pageSize);
                var devicesListResponse = _mapper.Map<IEnumerable<Device>, List<DeviceResponse>>(devices);
                _logger.LogInformation($"Dispositivos encontrados na página {pageNumber} da {pageSize}.");

                return new DevicesListResponse
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Devices = devicesListResponse
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar encontrar todos os dispositivos cadastrados.");
                throw;
            }
        }

        public async Task AddDevice(DeviceRequest deviceRequest)
        {
            try
            {
                var device = _mapper.Map<DeviceRequest, Device>(deviceRequest);
                await _repository.AddDevice(device);
                _logger.LogInformation("Dispositivo cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar um novo dispositivo.");
                throw;
            }
        }

        public async Task UpdateDevice(int deviceId, DeviceRequest deviceRequest)
        {
            try
            {
                var device = await _repository.GetDeviceById(deviceId);
                if (device == null)
                {
                    throw new InvalidOperationException("Device not found.");
                }

                _mapper.Map(deviceRequest, device);
                await _repository.UpdateDevice(deviceId, device);
                _logger.LogInformation("Dispositivo atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar atualizar um dispositivo.");
                throw;
            }
        }

        public async Task DeleteDevice(int deviceId)
        {
            try
            {
                await _repository.DeleteDevice(deviceId);
                _logger.LogInformation("Dispositivo removido com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar remover um dispositivo.");
                throw;
            }
        }

        public PortsResponse CalculateTotalPorts(List<DeviceResponse> devices)
        {
            try
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

                _logger.LogInformation("Portas de todos os dispositivos somadas com sucesso.");
                return totalPorts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar somar as portas de todos os dispositivos da lista.");
                throw;
            }
        }
    }
}