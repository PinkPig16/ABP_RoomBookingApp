using ABP_ConferenceBookingApp.Model;
using ABP_ConferenceBookingApp.Model.DTO;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface BookingHallService
    {
        Task<Decimal> BookingHall(BookingHall bookingHall);
        Task<Decimal> CalculatePrice(BookingHall bookingHall);
        Task<IEnumerable<HallConference>> GetHallsAsync(HallSearchCriteriaDto dto);
    }
}
