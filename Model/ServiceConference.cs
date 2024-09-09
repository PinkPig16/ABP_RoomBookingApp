using System.ComponentModel.DataAnnotations;

namespace ABP_ConferenceBookingApp.Model
{
    public class ServiceConference
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public ICollection<HallConference>? Conferences { get; set; }
        public ICollection<BookingHall>? bookingHalls { get; set; }
    }
}
