using System.ComponentModel.DataAnnotations.Schema;

namespace ABP_ConferenceBookingApp.Model
{
    public class BookingHall
    {
        public int Id { get; set; }
        public HallConference? hallConference { get; set; }
        public DateOnly BookingDate {  get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Decimal TotalPrice { get; set; }
        public ICollection<ServiceConference> ServiceConferences { get; set; }

    }
}
