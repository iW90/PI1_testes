using System.ComponentModel.DataAnnotations;

namespace PortsCalculator.App.Models.Requests
{
    public class DeviceRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do dispositivo deve ter entre 3 e 100 caracteres.")]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser um número positivo.")]
        public int AnalogicalInput { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser um número positivo.")]
        public int AnalogicalOutput { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser um número positivo.")]
        public int DigitalInput { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser um número positivo.")]
        public int DigitalOutput { get; set; }
    }
}
