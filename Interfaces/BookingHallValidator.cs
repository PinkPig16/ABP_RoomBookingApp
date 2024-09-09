using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Interfaces
{
    public interface BookingHallValidator
    {
        bool ValidateBookingHall(BookingHall bookingHall, out List<string> errors);
    }
}