using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortsCalculator.App.Models.Responses
{
    public class PortsResponse
    {
        public int AnalogicalInput { get; set; }

        public int AnalogicalOutput { get; set; }

        public int DigitalInput { get; set; }

        public int DigitalOutput { get; set; }
    }
}
