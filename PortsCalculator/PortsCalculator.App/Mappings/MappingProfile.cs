using AutoMapper;
using PortsCalculator.App.Models.Requests;
using PortsCalculator.App.Models.Responses;
using PortsCalculator.Core.Entities;

namespace PortsCalculator.App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeviceRequest, Device>()
                .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Device, DeviceResponse>();

            CreateMap<DeviceResponse, Device>();

            CreateMap<IEnumerable<Device>, List<DeviceResponse>>();

            CreateMap<List<DeviceResponse>, DevicesListResponse>()
                .ForMember(dest => dest.Devices, font => font.MapFrom(src => src));
        }
    }
}
