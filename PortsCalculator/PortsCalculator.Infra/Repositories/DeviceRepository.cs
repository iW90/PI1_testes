using Microsoft.EntityFrameworkCore;
using PortsCalculator.Core.Entities;
using PortsCalculator.Infra.Database;

namespace PortsCalculator.Infra.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca um dispositivo no banco através da Id
        public async Task<Device?> GetDeviceById(int deviceId)
        {
            return await _context
                .Devices
                    .FindAsync(deviceId);
        }

        // Busca um dispositivo no banco através do Nome
        public async Task<Device?> GetDeviceByName(string deviceName)
        {
            return await _context
                .Devices
                    .Where(x => x.Name.Contains(deviceName))
                    .FirstOrDefaultAsync();
        }

        // Retorna todos os dispositivos do banco em ordem alfabética
        public async Task<IEnumerable<Device>> DevicesList(int pageNumber, int pageSize)
        {
            return await _context
                .Devices
                    .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .Skip(pageNumber - 1)
                    .Take(pageSize)
                    .ToListAsync();
        }

        // Cadastra um novo dispositivo no banco
        public async Task<Task> AddDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        // Atualiza um dispositivo no banco através da Id
        public async Task<Task> UpdateDevice(int deviceId, Device updatedDevice)
        {
            var device = await _context.Devices.FindAsync(deviceId);

            if (device != null)
            {
                device.Name = updatedDevice.Name;
                device.Description = updatedDevice.Description;
                device.AnalogicalInput = updatedDevice.AnalogicalInput;
                device.AnalogicalOutput = updatedDevice.AnalogicalOutput;
                device.DigitalInput = updatedDevice.DigitalInput;
                device.DigitalOutput = updatedDevice.DigitalOutput;

                await _context.SaveChangesAsync();

                return Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Device not found.");
            }
        }


        // Deleta um dispositivo no banco através da Id
        public async Task<Task> DeleteDevice(int deviceId)
        {
            var deviceToDelete = await _context
                .Devices
                    .FindAsync(deviceId);

            if (deviceToDelete != null)
            {
                _context
                    .Devices
                    .Remove(deviceToDelete);
                await _context
                    .SaveChangesAsync();

                return Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Device not found.");
            }
        }
    }
}
