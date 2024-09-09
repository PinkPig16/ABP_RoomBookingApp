namespace ABP_ConferenceBookingApp.Model.DTO
{
    public class BookingHallDto
    {

        public string BookingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ICollection<BookingServiceDto>? ServiceConferences { get; set; }
    }
}
