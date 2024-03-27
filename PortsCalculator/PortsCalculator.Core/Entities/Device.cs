using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortsCalculator.Core.Entities
{
    public class Device
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int AnalogicalInput { get; set; }

        public int AnalogicalOutput { get; set; }

        public int DigitalInput { get; set; }

        public int DigitalOutput { get; set; }

        public Device(string name, string? description, int analogicalInput, int analogicalOutput, int digitalInput, int digitalOutput)
        {
            Name = name;
            Description = description;
            AnalogicalInput = analogicalInput;
            AnalogicalOutput = analogicalOutput;
            DigitalInput = digitalInput;
            DigitalOutput = digitalOutput;
        }
    }
}
