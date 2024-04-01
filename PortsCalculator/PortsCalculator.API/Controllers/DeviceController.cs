using PortsCalculator.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using PortsCalculator.App.UseCases;
using PortsCalculator.App.Models.Requests;
using PortsCalculator.App.Models.Responses;

namespace PortsCalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : DeviceBaseController
    {
        private readonly IDeviceUseCase _deviceUseCase;

        public DeviceController(IDeviceUseCase deviceUseCase)
        {
            _deviceUseCase = deviceUseCase;
        }

        /// <summary>
        /// Busca um dispositivo pela ID.
        /// </summary>
        /// <param name="id">O ID do dispositivo a ser encontrado.</param>
        /// <returns>O dispositivo com o ID especificado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceResponse>> GetDeviceById(int id)
        {
            var device = await _deviceUseCase.GetDeviceById(id);
            return HandleActionResult(device);
        }

        /// <summary>
        /// Busca um dispositivo pelo nome.
        /// </summary>
        /// <param name="name">O nome do dispositivo a ser encontrado.</param>
        /// <returns>O dispositivo com o nome especificado.</returns>
        [HttpGet("byname/{name}")]
        public async Task<ActionResult<DeviceResponse>> GetDeviceByName(string name)
        {
            var device = await _deviceUseCase.GetDeviceByName(name);
            return HandleActionResult(device);
        }

        /// <summary>
        /// Busca os dispositivos cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os dispositivos.</returns>
        [HttpGet("/devices")]
        public async Task<ActionResult<IEnumerable<DeviceResponse>>> GetAllDevices(int pageNumber, int pageSize)
        {
            var devices = await _deviceUseCase.GetAllDevices(pageNumber, pageSize);
            return HandleActionResult(devices);
        }

        /// <summary>
        /// Cadastra um novo dispositivo.
        /// </summary>
        /// <param name="device">O dispositivo a ser cadastrado.</param>
        /// <returns>O status de cadastramento do dispositivo.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceRequest device)
        {
            try
            {
                await _deviceUseCase.AddDevice(device);
                return HandleNoContentResult();
            }
            catch (InvalidOperationException ex)
            {
                return HandleBadRequestResult(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um dispositivo existente através da id.
        /// </summary>
        /// <param name="id">A ID do dispositivo a ser atualizado.</param>
        /// <param name="device">Os novos dados do dispositivo.</param>
        /// <returns>O status de atualização do dispositivo.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] DeviceRequest device)
        {
            try
            {
                await _deviceUseCase.UpdateDevice(id, device);
                return HandleNoContentResult();
            }
            catch (InvalidOperationException ex)
            {
                return HandleBadRequestResult(ex.Message);
            }
            catch (Exception ex)
            {
                return HandleInternalServerErrorResult(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um dispositivo cadastrado pela ID.
        /// </summary>
        /// <param name="id">A ID do dispositivo a ser excluído.</param>
        /// <returns>O status de exclusão do dispositivo.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            try
            {
                await _deviceUseCase.DeleteDevice(id);
                return HandleNoContentResult();
            }
            catch (InvalidOperationException ex)
            {
                return HandleBadRequestResult(ex.Message);
            }
            catch (Exception ex)
            {
                return HandleInternalServerErrorResult(ex.Message);
            }
        }

        /// <summary>
        /// Calcula o número total de portas de uma lista de dispositivos.
        /// </summary>
        /// <param name="devices">Uma lista de dispositivos.</param>
        /// <returns>O número total de portas de entrada e de saída, analógicas e digitais.</returns>
        [HttpGet]
        public IActionResult GetTotalPorts([FromBody] List<DeviceResponse> devices)
        {
            var totalPorts = _deviceUseCase.CalculateTotalPorts(devices);

            if (totalPorts == null)
            {
                return HandleNotFoundResult("Nenhum dispositivo encontrado para calcular as portas.");
            }
            return HandleActionResult(totalPorts);
        }
    }
}
