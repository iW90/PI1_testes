using PortsCalculator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortsCalculator.App.Models.Responses
{
    public class DeviceResponse
    {
        public int Id {  get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int AnalogicalInput { get; set; }

        public int AnalogicalOutput { get; set; }

        public int DigitalInput { get; set; }

        public int DigitalOutput { get; set; }
    }
}
