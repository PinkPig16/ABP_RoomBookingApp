using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ABP_RoomBookingApp.Model
{
    public class PriceModifiers
    {
        public int Id { get; set; }
        public DateTime dateStart {  get; set; }
        public DateTime dateEnd { get; set; }
        public float Discount { get; set; } = 1F;
    }
}
