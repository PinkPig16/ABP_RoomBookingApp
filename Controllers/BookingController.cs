using ABP_ConferenceBookingApp.Interfaces;
using ABP_ConferenceBookingApp.Model;
using ABP_ConferenceBookingApp.Model.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ABP_ConferenceBookingApp.Controllers
{
    [ApiController]
    [Route("api/Booking")]
    public class BookingController : Controller
    {
        private readonly BookingHallService _bookingHallService;
        private readonly IMapper _mapper;
        private readonly ServiceConferenceService _serviceConferenceService;
        private readonly HallConferenceRepository _hallRepository;

        public BookingController(IMapper mapper,
                                BookingHallService bookingHallService,
                                ServiceConferenceService serviceConferenceService,
                                HallConferenceRepository hallRepository) 
        {
            _mapper = mapper;
            _bookingHallService = bookingHallService;
            _serviceConferenceService = serviceConferenceService;
            _hallRepository = hallRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableHalls([FromQuery] string date, [FromQuery] string StartTime, string EndTime, [FromQuery] int capacity)
        {
            var bookingHall = new HallSearchCriteriaDto

            {
                Date = DateOnly.Parse(date),
                StartTime = TimeOnly.Parse(StartTime),
                EndTime = TimeOnly.Parse(EndTime),
                Capacity = capacity
            };
            var availableHalls = await _bookingHallService.GetHallsAsync(bookingHall);
            return Ok(availableHalls);
        }
        [HttpPost]
        public async Task<IActionResult> BookHall([FromQuery] int id,  [FromBody] BookingHallDto dto)
        {
            var bookingDate = DateTime.Parse(dto.BookingDate);
            var bookingHall = new BookingHall

            {
                BookingDate = DateOnly.Parse(dto.BookingDate),
                StartTime = TimeOnly.Parse(dto.StartTime),
                EndTime = TimeOnly.Parse(dto.EndTime),
                ServiceConferences = dto.ServiceConferences
                            .Select(sc => new ServiceConference
                            {
                                Name = sc.Name
                            }).ToList()
            };
            bookingHall.hallConference = await _hallRepository.GetAsyncById(id);
            if (bookingHall.ServiceConferences != null)
            {
                bookingHall.ServiceConferences = await _serviceConferenceService.CheckServiceConference(bookingHall.ServiceConferences);
            }
            var totalPrice = await _bookingHallService.BookingHall(bookingHall);
            return Ok(new {Message = $"Rent confirmation. Total price {totalPrice}" });
        }
    }
}
