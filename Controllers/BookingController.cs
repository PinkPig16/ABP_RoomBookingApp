using Microsoft.AspNetCore.Mvc;

namespace ABP_RoomBookingApp.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> GetAvailableHalls(DateTime date, TimeSpan time, int capacity)
        {
            return View();
        }
        public async Task<IActionResult> BookHall()
        {
            return View();
        }
    }
}
