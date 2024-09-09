using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ABP_ConferenceBookingApp.Model
{
    public class PriceModifiers
    {
        public int Id { get; set; }
        public TimeOnly dateStart {  get; set; }
        public TimeOnly dateEnd { get; set; }
        public float Discount { get; set; } = 1F;
    }
}
