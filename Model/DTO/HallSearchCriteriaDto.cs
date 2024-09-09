namespace ABP_ConferenceBookingApp.Model.DTO
{
    public class HallSearchCriteriaDto
    {
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int Capacity { get; set; }
    }
}
