using ABP_ConferenceBookingApp.Model.DTO;
using ABP_ConferenceBookingApp.Model;
using AutoMapper;

namespace ABP_ConferenceBookingApp.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HallConferenceDto, HallConference>();
            CreateMap<ServiceConferenceDto, ServiceConference>();
            CreateMap<BookingHallDto, BookingHall>();
            CreateMap<BookingServiceDto, ServiceConference>();
        }
    }
}
