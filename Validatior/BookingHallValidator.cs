using ABP_ConferenceBookingApp.Model;

namespace ABP_ConferenceBookingApp.Validatior
{
    public class BookingHallValidator : Interfaces.BookingHallValidator
    {
        public bool ValidateBookingHall(BookingHall bookingHall, out List<string> errors)
        {
            errors = new List<string>();

            if ((bookingHall.EndTime - bookingHall.StartTime).TotalHours <= 0) 
            {
                errors.Add("Rent must be at least 1 hour");
            }
            if (bookingHall.hallConference == null)
            {
                errors.Add("conference hall not found.");
            }

            return errors.Count == 0;
        }
    }
}
