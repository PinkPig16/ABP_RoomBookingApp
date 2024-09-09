namespace ABP_ConferenceBookingApp.Model.DTO
{
    public class HallConferenceDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public List<ServiceConferenceDto>? ServiceConferences { get; set; }
    }
}
