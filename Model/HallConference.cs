using System.ComponentModel.DataAnnotations;

namespace ABP_ConferenceBookingApp.Model
{
    public class HallConference
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Decimal Price { get; set; }
        public ICollection<ServiceConference>? ServiceConferences { get; set; }
    }
}
