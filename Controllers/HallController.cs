using ABP_RoomBookingApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ABP_RoomBookingApp.Controllers
{
    public class HallController : Controller
    {
        public async Task<IActionResult> AddHall()
        {
            return View();
        }
        public async Task<IActionResult> UpdateHall()
        {
            return View();
        }
        public async Task<IActionResult> DeleteHall()
        {
            return View();
        }
    }
}
