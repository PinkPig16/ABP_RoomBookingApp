using System.ComponentModel.DataAnnotations;

namespace ABP_RoomBookingApp.Model
{
    public class ServiceConference
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<HallConference>? Conferences { get; set; }
    }
}
