using ABP_ConferenceBookingApp.Model;
using ABP_ConferenceBookingApp.Model.DTO;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface BookingHallRepository
    {
        Task<BookingHall?> GetAsyncById(int id);
        Task<IEnumerable<BookingHall>> GetAllAsync();
        Task<bool> Add(BookingHall bookingHall);
        Task<bool> UpdateAsync(BookingHall bookingHall);
        Task<bool> DeleteAsync(BookingHall bookingHall);
        Task<IEnumerable<HallConference>> GetAvailableHalls(HallSearchCriteriaDto dto);
        Task<bool> SaveChangeAsync();
    }
}
