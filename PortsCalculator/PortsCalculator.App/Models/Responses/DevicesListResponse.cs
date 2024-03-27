using PortsCalculator.App.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortsCalculator.App.Models.Responses
{
    public class DevicesListResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public required List<DeviceResponse> Devices { get; set; }
    }
}
